using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tz.Common.DataModel;

namespace Tz.Locker.DataModel.Entity
{
    [ReadonlyTable]
    public class ParcelView
    {
        [Key]
        public Guid ParcelId { get; set; }

        public bool IsExpired { get; set; }

        public Guid LockerBankId { get; set; }

        public Guid? LockerId { get; set; }

        [ForeignKey("LockerBankId")]
        public virtual LockerBank LockerBanks { get; set; }

    }
}