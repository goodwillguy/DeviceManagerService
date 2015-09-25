using Common.DataModel;
using Common.Values;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locker.DataModel.Entity
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