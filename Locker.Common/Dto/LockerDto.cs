using Tz.Common.Values;
using Tz.Common.Values.Enums;
using System;

namespace Tz.Locker.Common.Dto
{
    public class LockerDto:Base
    {
        public Guid LockerId { get; set; }

        public Guid LockerBankId { get; set; }

        public LockerState State { get; set; }

        public Size Size { get; set; }

        public Guid? LockerOfflineReasonId { get; set; }

        public int Column { get; set; }
        public string LockerNumber { get; set; }

        public string DeviceSerialNumber { get; set; }
    }
}