using System;

namespace Tz.ApplicationServices.Common
{
    public class LockerDataDto
    {
        public Guid? LockerId { get; set; }
        public string LockerNumber { get; set; }
        public string DeviceSerialNumber { get; set; }
    }
}