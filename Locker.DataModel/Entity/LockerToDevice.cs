using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Locker.DataModel.Entity
{
    [Table("LockerToDevice")]
    public class LockerToDevice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid LockerToDeviceId { get; set; }
        public Guid LockerId { get; set; }
        public Guid DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device DeviceData { get; set; }
        [ForeignKey("LockerId")]
        public virtual Locker Locker { get; set; }

    }
}
