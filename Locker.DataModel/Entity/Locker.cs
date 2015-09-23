using Common.DataModel;
using Common.DataModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public LockerSize Size { get; set; }

        public Guid? LockerOfflineReasonId { get; set; }

    }
}
