using Common.DataModel;
using Common.Values;
using Common.Values.Enums;
using Locker.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locker.DataModel
{
    public class Locker : Base, IAuditable
    {
        [Key]
        public Guid LockerId { get; set; }

        [Required]
        public Guid LockerBankId { get; set; }

        public LockerState State { get; set; }

        public Size Size { get; set; }

        public Guid? LockerOfflineReasonId { get; set; }

        [ForeignKey("LockerBankId")]
        public virtual LockerBank LockerBanks { get; set; }

        public virtual List<LockerToDevice> DevicesInLocker { get; set; }

    }
}
