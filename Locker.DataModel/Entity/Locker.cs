using Tz.Common.DataModel;
using Tz.Common.Values;
using Tz.Common.Values.Enums;
using Tz.Locker.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Locker.DataModel
{
    [Table("Locker")]
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

        public string LockerNumber { get; set; }

    }
}
