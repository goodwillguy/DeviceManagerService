using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TZ.API.DeviceManagement.Properties;
using TZ.DeviceManagement.DeviceContract.Enums;
using TZ.DeviceManagement.DeviceContract.Logging;
using TZ.DeviceManagement.EventHandlers;
using System.Runtime.Caching;
using TZ.Common;
using TZ.ServiceModel;
using TZ.DeviceManagement;
using TZ.DeviceManagement.Interfaces;
using TZLogger = TZ.DeviceManagement.DeviceContract.Logging.TZEventLog;
using TZ.DeviceManagement.Enums;
using System.ServiceModel;
using System.Diagnostics;
using CommonInterface;

namespace TZ.API.DeviceManagement
{
    public class DeviceManager : ServiceBase, IDeviceManager
    {
       
        public event EventHandler<EventArgs> DiscoveryComplete;
        private readonly TZDeviceManager _deviceManager = TZDeviceManager.Instance;
        private List<Device> _devices = new List<Device>();
        private Dictionary<string, ITZGenericDevice> _offlineDevices = new Dictionary<string, ITZGenericDevice>();
        private bool _logDebugMessages = false;
        ManualResetEventSlim _waitHandler = new ManualResetEventSlim(false);
        public bool DisableValidation { get; set; }

        private readonly MemoryCache _cache = new MemoryCache("error entry");
        private readonly CacheItemPolicy _cacheItemPolicy = new CacheItemPolicy() { SlidingExpiration = TimeSpan.FromSeconds(30) };

        public DeviceManager(ILogger logger, IComPortProvider comPortProvider, ICardReaderService cardReaderListner)
        {
            _logger = logger;
            _comPortProvider = comPortProvider;
            _cardReaderListner = cardReaderListner;
            InitializeService();
        }


        private class ErrorEntry
        {
            public DateTime CreationTime { get; set; }

            public DateTime LastWriteTime { get; set; }
        }

        private void LogError(string message)
        {
            bool writeToLog = false;
            ErrorEntry errorEntry;


            DateTime now = DateTime.Now;
            if (!this._cache.Contains(message))
            {
                writeToLog = true;
                errorEntry = new ErrorEntry() { CreationTime = now, LastWriteTime = now };
                this._cache.Add(message, errorEntry, this._cacheItemPolicy);
            }
            else
            {
                errorEntry = (ErrorEntry)this._cache[message];

                TimeSpan duration = now - errorEntry.CreationTime;

                if (duration < TimeSpan.FromSeconds(30))
                {
                    writeToLog = true;
                }
                else if (duration < TimeSpan.FromMinutes(1))
                {
                    writeToLog = now - errorEntry.LastWriteTime > TimeSpan.FromSeconds(10);
                }
                else if (duration < TimeSpan.FromMinutes(5))
                {
                    writeToLog = now - errorEntry.LastWriteTime > TimeSpan.FromMinutes(1);
                }
                else
                {
                    writeToLog = now - errorEntry.LastWriteTime > TimeSpan.FromMinutes(5);
                }

            }

            if (writeToLog)
            {
                errorEntry.LastWriteTime = now;
                _logger.SafeLogError("TZDeviceManager", message);
            }
        }

        protected virtual void OnDiscoveryComplete(EventArgs e)
        {
            _discovered = true;

            if (this.DiscoveryComplete != null)
            {
                this.DiscoveryComplete(this, e);
            }
        }

        public override void InitializeService()
        {
            TZLogger.ErrorEvent += EventLog_ErrorEvent;
            TZLogger.OutputEvent += EventLog_OutputEvent;

            _deviceManager.DeviceChangedHandler += DeviceChangedHandler;
            _deviceManager.DeviceManagementInformationHandler += InformationHandler;
            _deviceManager.DiscoveryCompleteHandler += DiscoveryCompleteInfo;
            _deviceManager.DeviceSensorChangedHandler += DeviceSensorChangedHandler;



            if (this.DisableValidation)
            {
                _deviceManager.RetryOnDeviceMissing = 0;
            }

            // read device manager configs from settings
            _deviceManager.ReLoadDevicesOnError = Settings.Default.ReloadDevicesOnError;
            _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the ReloadDevicesOnError flag to {0}", Settings.Default.ReloadDevicesOnError));
            _deviceManager.ReloadOnStartUp = Settings.Default.ReloadOnStartUp;
            _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the ReloadOnStartUp flag to {0}", Settings.Default.ReloadOnStartUp));
            _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the Polling Interval to {0}", Settings.Default.PollingInterval));
            _deviceManager.DevicePollingInterval = Settings.Default.PollingInterval;
            _logDebugMessages = Settings.Default.LogDebugMessages;
            _deviceManager.MaxDeviceCommandRetry = Settings.Default.MaxCommandRetry;
            _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the MaxDeviceCommandRetry flag to {0}", Settings.Default.MaxCommandRetry));
            _deviceManager.DeviceCommandRetryInterval = Settings.Default.CommandRetryInterval;
            _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the DeviceCommandRetryInterval flag to {0}", Settings.Default.CommandRetryInterval));
            _deviceManager.DiscoveryResponseWindow = Settings.Default.DiscoveryResponseWindow;
            _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the DiscoveryResponseWindow flag to {0}", Settings.Default.DiscoveryResponseWindow));
            _deviceManager.MaxResponseDelayForOnlineStatus = Settings.Default.MaxOnlineStatusDelay;
            _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the MaxResponseDelayForOnlineStatus flag to {0}", Settings.Default.MaxOnlineStatusDelay));
            _deviceManager.EmulateDevices = Settings.Default.Emulation;
            _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the Emulation of Devices flag to {0}", Settings.Default.Emulation));
            if (Settings.Default.Emulation)
            {
                _deviceManager.NumEmulatedRadials = Settings.Default.NumberOfEmulatedRadials;
                _logger.SafeLogMessage("TZDeviceManager", string.Format("Set the Number of Emulated Devices to {0}", Settings.Default.NumberOfEmulatedRadials));

            }
            // call the discovery start process
            Task.Factory.StartNew(SetupNetwork);

            //base.InitializeService();
        }

        void DeviceSensorChangedHandler(object sender, TZDeviceSensorChangedEventArgs e)
        {

            switch (e.ChangedSensorType)
            {

                case TZSensorTypes.RFIDSwipe:
                    {
                        var RFID = e.ChangedDevice.GetRFIDNumber();
                        var serialNumber = e.ChangedDevice.GetSerialNumber();
                        if (!string.IsNullOrEmpty(RFID))
                        {
                            _logger.SafeLogMessage("TZDeviceManager", string.Format("RFID {0} swiped from {1}", RFID, serialNumber));

                            var device = _devices.FirstOrDefault(d => d.SerialNumber.Trim() == serialNumber.Trim());
                            if (device != null)
                            {
                                _cardReaderListner.OnSwipe(new SwipeEventArgs() { SerialNumber = device.FullSerialNumber, RFID = RFID });
                            }
                        }
                    }

                    break;
            }

        }

        private void SetupNetwork()
        {
            _logger.SafeLogMessage("TZDeviceManager", "Initialize Device Network.");
            IComPortProvider cpp = _comPortProvider;
            string comPort = cpp != null ? cpp.ComPort : null;

            cpp = null;
            if (string.IsNullOrEmpty(comPort))
            {
                _logger.SafeLogMessage("TZDeviceManager", "No COM port specified, Detecting COM port...");
                comPort = _deviceManager.GetFirstUSBPort();
            }

            bool retry = false;
            do
            {
                string msg = string.Empty;

                try
                {
                    _discovered = false;
                    msg = _deviceManager.DiscoverDevices(comPort);
                    retry = msg != "OK";


                }
                catch (Exception ex)
                {
                    _logger.SafeLogError("TZDeviceManager", ex, "Device Manager is failed to initialize");

                }

                if (retry)
                {
                    _logger.SafeLogError("TZDeviceManager", "Device Manager is failed to initialize : {0}. Retry in 30 seconds.", msg);
                    Task.Delay(30 * 1000).Wait();
                }

            } while (retry);
        }

        private void DiscoveryCompleteInfo(object sender, TZDeviceDiscoveryEventArgs e)
        {
            var devices = _deviceManager.GetDeviceList();
            if (_devices != null)
                _devices.Clear();
            _devices = devices.Select(d => new Device
            {
                SerialNumber = d.GetSerialNumber(),
                FullSerialNumber = d.GetFullSerialNumber(),
                DeviceType = d.GetDeviceType() == TZ.DeviceManagement.Common.Constants.DeviceType.RFIDReader ? DeviceType.CardReader : DeviceType.Lock

            }).ToList();

            _waitHandler.Set();
            OnDiscoveryComplete(EventArgs.Empty);

        }

        private void UpdateDevice(ITZGenericDevice tzLock)
        {
            if (tzLock == null) return;
            var device = _devices.Find(d => d.SerialNumber == tzLock.GetSerialNumber());

            var lockState = tzLock.GetLockState();

            lock (_devices)
            {
                device.LastChangeTime = DateTimeHelper.GetUtcNow();
                device.DeviceStatus = GetDeviceStatus(lockState);
            }
        }

        private DeviceStatus GetDeviceStatus(string lockState)
        {
            var status = DeviceStatus.Unknown;
            switch (lockState)
            {
                case TZ.DeviceManagement.Common.Constants.DeviceStatus.Locked:
                    status = DeviceStatus.Locked;
                    break;
                case TZ.DeviceManagement.Common.Constants.DeviceStatus.Error:
                    status = DeviceStatus.Unknown;
                    break;
                case TZ.DeviceManagement.Common.Constants.DeviceStatus.Unlocked:
                    status = DeviceStatus.Unlocked;
                    break;
            }
            return status;
        }

        void EventLog_ErrorEvent(TZLogEventArgs e)
        {
            LogError(e.Message);
        }

        void EventLog_OutputEvent(TZLogEventArgs e)
        {
            Debug.WriteLine(e.Message);
            if (e.Level == TZLogLevel.ERROR)
            {
                _logger.SafeLogError("TZDeviceManager", e.Message);
            }
            else if (e.Level == TZLogLevel.INFORMATION)
            {
                _logger
                        .SafeLogMessage("TZDeviceManager", e.Message);
            }
            else if (e.Level == TZLogLevel.OUTPUT && _logDebugMessages)
            {
                _logger
                        .SafeLogMessage("TZDM-Debug", e.Message);
            }
        }

        private string ToSerialNumberString(byte[] bytes)
        {

            string rs = "";
            foreach (var b in bytes)
            {
                rs += b.ToString("X2") + " ";
            }

            return rs;
        }

        public void DeviceChangedHandler(object sender, TZDeviceChangedEventArgs e)
        {
            var tzLock = e.ChangedDevice;
            if (tzLock == null) return;
            var device = _devices.Find(d => d.SerialNumber == tzLock.GetSerialNumber());
            if (device == null) return;

            var currDeviceStatus = GetDeviceStatus(tzLock.GetLockState());

            // the device change can be with respect to any as Lock state, Stud State, Analog Sensor State which is LED as well as Bypass state
            // but here we are interested only with the Lock state change and so check only that and update
            if (device.DeviceStatus == currDeviceStatus) return;

            UpdateDevice(tzLock);

            if (tzLock.GetLockState() == TZ.DeviceManagement.Common.Constants.DeviceStatus.Error)
            {
                LogError(string.Format("Action Occurred {0}, status : {1}", tzLock.GetFullSerialNumber(), tzLock.GetLockState()));
            }
            else
            {
                _logger
                    .SafeLogMessage("TZDeviceManager", "Action Occurred {0}, status : {1}", tzLock.GetFullSerialNumber(),
                        tzLock.GetLockState());
            }

            if (this.DeviceChanged != null)
                DeviceChanged.Invoke(this, new DeviceChangedEventArg(device));
        }

        protected virtual void OnDeviceInitialized(EventArgs e)
        {
            if (this.DeviceInitialized != null)
            {
                this.DeviceInitialized(this, e);
            }
        }

        public event EventHandler DeviceInitialized;

        public void InformationHandler(object sender, TZDeviceManagementInformarionEventArgs e)
        {
            if (e.InformationType == TZ.DeviceManagement.Enums.TZDeviceManagementInfoTypes.AllDevicesInitialized)
            {
                _waitHandler.Wait();
                this._isReady = true;
                this.OnDeviceInitialized(e);
            }

            if (e.InformationType == TZ.DeviceManagement.Enums.TZDeviceManagementInfoTypes.DeviceCommunicationErrorInfo)
            {
                HandleDeviceError();
            }

            var message = string.Format("Message of type {0} with message {1} received", e.InformationType, e.Message);
            _logger.SafeLogMessage("TZDeviceManager", message);
        }

        private void HandleDeviceError()
        {
            // get offline devices from device manager
            var offlineDevices = _deviceManager.AnyLocksOffline();
            Dictionary<string, ITZGenericDevice> offlineDeviceSerialNumbers = new Dictionary<string, ITZGenericDevice>();

            if (offlineDevices != null)
            {
                foreach (var offlineDevice in offlineDevices)
                {
                    string serialNumber = offlineDevice.GetFullSerialNumber();
                    var device = _devices.Find(d => d.FullSerialNumber == serialNumber);

                    var currDeviceStatus = GetDeviceStatus(offlineDevice.GetLockState());

                    if (device.DeviceStatus == currDeviceStatus) continue;

                    UpdateDevice(offlineDevice);
                }
            }
        }


        public override void UninitializeService()
        {
            base.UninitializeService();
            TZLogger.ErrorEvent -= EventLog_ErrorEvent;
            TZLogger.OutputEvent -= EventLog_OutputEvent;
            _deviceManager.DeviceChangedHandler -= DeviceChangedHandler;
            _deviceManager.DeviceManagementInformationHandler -= InformationHandler;
            _deviceManager.DiscoveryCompleteHandler -= DiscoveryCompleteInfo;
        }

        public Device[] GetAllDevices()
        {
           while(!_discovered)
            {
                Thread.Sleep(1000);
            }

            return _devices.ToArray();
        }

        public Device GetDevice(string serialNumber)
        {
            var device = _devices.Find(d => d.FullSerialNumber.Trim() == serialNumber.Trim());
            return device;
        }

        public bool Open(string serialNumber)
        {
            _logger.SafeLogMessage("TZDeviceManager", "Received command to open lock {0}.", serialNumber);
            var device = _devices.FirstOrDefault(d => d.FullSerialNumber == serialNumber);
            if (device == null) return false;
            return TZ.DeviceManagement.Common.Constants.DeviceStatus.Unlocked == _deviceManager.OpenLock(device.SerialNumber);
        }

        public void Open(string[] serialNumbers)
        {
            var shortSns = from d in this._devices
                           where serialNumbers.Contains(d.FullSerialNumber)
                           select d.SerialNumber;
            _deviceManager.OpenLocks(shortSns.ToList());




        }

        private string _firmwareVersion = null;
        public string GetFirmwareVersion()
        {
            return _firmwareVersion;
        }

        #region IDeviceManager Members

        private bool _isReady = false;
        private readonly ILogger _logger;
        private readonly IComPortProvider _comPortProvider;
        private bool _discovered;
        private readonly ICardReaderService _cardReaderListner;

        public bool IsReady()
        {
            return _isReady;
        }

        #endregion

        #region ICardReaderService Members

        protected virtual void OnSwipe(SwipeEventArgs e)
        {
            if (this.Swipe != null)
            {
                this.Swipe(this, e);
            }
        }

        public event EventHandler<SwipeEventArgs> Swipe;
        public event EventHandler<DeviceChangedEventArg> DeviceChanged;

        #endregion
    }
}
