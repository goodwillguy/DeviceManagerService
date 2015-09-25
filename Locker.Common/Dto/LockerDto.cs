using Common.Values;
using Common.Values.Enums;
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
    }
}