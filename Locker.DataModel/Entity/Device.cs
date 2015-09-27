using Tz.Common.DataModel;
using Tz.Common.Values;
using Tz.Common.Values.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tz.Locker.DataModel
{
    [Table("Device")]
    public class Device:Base,IAuditable
    {
        [Key]
        public Guid DeviceId { get; set; }
        public Guid LockerBankId { get; set; }

        public string SerialNumber { get; set; }
        public bool IsEnabled { get; set; }

        public DeviceType DeviceType { get; set; }

        [ForeignKey("LockerBankId")]
        public virtual LockerBank LockerBank { get; set; }

    }
}
