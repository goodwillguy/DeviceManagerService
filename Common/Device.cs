using System;

namespace Tz.LockerBank.Common.Interface
{
    
    public class Device
    {
       
        public string SerialNumber { get; set; }
        public string FullSerialNumber { get; set; }
        private DeviceStatus _deviceStatus = DeviceStatus.Unknown;
        public DeviceStatus DeviceStatus
        {
            get
            {
                return _deviceStatus;
            }
            set
            {
                if (_deviceStatus != value)
                {
                    LastChangeTime = DateTime.Now;
                    _deviceStatus = value;
                }
            }
        }

        public DateTime LastChangeTime { get; set; }

        public DeviceType DeviceType { get; set; }
    }
}
