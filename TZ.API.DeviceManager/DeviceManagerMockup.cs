namespace TZ.API.DeviceManagement
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TZ.ServiceModel;
    using TZ.Common;
    using Tz.LockerBank.Common.Interface;

    public class DeviceManagerMockup : ServiceBase, IDeviceManager
    {
        public event EventHandler<DeviceChangedEventArg> DeviceChanged;
        private readonly List<Device> _devices = new List<Device>();

        #region IDeviceManager Members

        public Device[] GetAllDevices()
        {
            this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Received GetAllDevices request");
            return _devices.ToArray();
        }

        protected virtual void OnDeviceInitialized(EventArgs e)
        {
            if (this.DeviceInitialized != null)
            {
                this.DeviceInitialized(this, e);
            }
        }

        public event EventHandler DeviceInitialized;

        public Device GetDevice(string serialNumber)
        {
            this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Received GetDevice request for serial number {0}", serialNumber);
            Device rs = this._devices.Find(d => d.FullSerialNumber.Trim() == serialNumber.Trim());
            if (rs == null)
            {
                this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Did not find the device, will add it now");
                rs = new Device {FullSerialNumber = serialNumber.Trim(), DeviceStatus = DeviceStatus.Locked};
                this._devices.Add(rs);

            }
            return rs;
        }


        public void Open(string[] serialNumbers)
        {
            foreach(string s in serialNumbers)
            {
                Open(s);
            }
        }

        public bool Open(string serialNumber)
        {
            this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Received Open request  for serial number {0}", serialNumber);
            Device device = this._devices.Find(d => d.SerialNumber.Trim() == serialNumber.Trim());
            if (device == null)
            {
                this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Did not find the device, will add it now");
                device = new Device() { FullSerialNumber = serialNumber, SerialNumber = serialNumber };
                this._devices.Add(device);
            }

            device.DeviceStatus = DeviceStatus.Unlocked;

            if (this.DeviceChanged != null)
                DeviceChanged.Invoke(this, new DeviceChangedEventArg(device));

            Task.Factory.StartNew((d) =>
            {
                Thread.Sleep(this._delay);
                ((Device)d).DeviceStatus = DeviceStatus.Locked;
                if (this.DeviceChanged != null)
                    DeviceChanged.Invoke(this, new DeviceChangedEventArg(device));
                this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Device {0} is locked", ((Device)d).SerialNumber);

            }, device);

            return true;
        }

       private const string FirmwareVersion = "mocked";

        public string GetFirmwareVersion()
        {
            return FirmwareVersion;
        }

        #endregion

        private TimeSpan _delay = TimeSpan.FromSeconds(5);
        public override void InitializeService()
        {

            if (CommandArgumentsHelper.HasArgument("device-delay"))
            {
                int seconds = Int32.Parse(CommandArgumentsHelper.GetValue("device-delay"));
                this._delay = TimeSpan.FromSeconds(seconds);
            }

            this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Mockup device manager started, device will be closed after {0} seconds", this._delay.TotalSeconds);

            var provider = this.Site.GetService<IMockUpDevicesProvider>();
            if(provider != null)
            {
                string[] sns = provider.GetSerialNumbers();
               
                foreach(string sn in sns)
                {
                    var device = new Device { SerialNumber = sn, DeviceStatus = DeviceStatus.Locked, FullSerialNumber = sn };
                    this._devices.Add(device);
                    this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "Device {0} is added", sn);
                }
                this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "IMockUpDevicesProvider is provided, {0} devices are added.",sns.Length);
            }
            else
            {
                this.Site.GetService<ILogger>().SafeLogMessage("DeviceManagerMockup", "IMockUpDevicesProvider is not provided.");
            }

            

            base.InitializeService();

            this.OnDeviceInitialized(EventArgs.Empty);
        }

        #region IDeviceManager Members


        public bool IsReady()
        {
            return true;
        }

        #endregion

      
    }



}
