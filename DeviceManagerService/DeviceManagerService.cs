using Tz.LockerBank.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TZ.API.DeviceManagement;
using TZ.ServiceModel;
using Tz.LockerBank.Common.Dto;

namespace Tz.DeviceManagerService
{
   
    public class DeviceManagerServiceHost : IDeviceManagerService
    {
        private readonly IDeviceManager _deviceManager;


        //public Tz.DeviceManagerService()
        //{

        //}

        public DeviceManagerServiceHost(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        //public Tz.DeviceManagerServiceHost(ILogger deviceManager)
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

        public void OpenLockers(string[] serialNumbers)
        {
             _deviceManager.Open(serialNumbers);
        }

        public bool Open(OpenDeviceDto deviceData)
        {
            return _deviceManager.Open(deviceData.SerialNumber);
        }
    }
}
