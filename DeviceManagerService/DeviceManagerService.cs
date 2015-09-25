using LockerBank.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;
using TZ.ServiceModel;

namespace DeviceManagerService
{
   
    public class DeviceManagerServiceHost : IDeviceManagerService
    {
        private readonly IDeviceManager _deviceManager;


        //public DeviceManagerService()
        //{

        //}

        public DeviceManagerServiceHost(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        //public DeviceManagerServiceHost(ILogger deviceManager)
        //{
           
        //}

        public event EventHandler<DeviceChangedEventArg> DeviceChanged;
        public event EventHandler DeviceInitialized;

        public Device[] GetAllDevices()
        {
            return _deviceManager.GetAllDevices();
        }

        public Device GetDevice(string serialNumber)
        {
            return _deviceManager.GetDevice(serialNumber);
        }

        public string GetFirmwareVersion()
        {
            return _deviceManager.GetFirmwareVersion();
        }

        public bool IsReady()
        {
            return _deviceManager.IsReady();
        }

        public void Open(string[] serialNumbers)
        {
             _deviceManager.Open(serialNumbers);
        }

        public bool Open(string serialNumber)
        {
            return _deviceManager.Open(serialNumber);
        }
    }
}
