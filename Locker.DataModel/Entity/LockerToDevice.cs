using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locker.DataModel.Entity
{
    public class LockerToDevice
    {
        public Guid LockerId { get; set; }
        public Guid DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public virtual Device DeviceData { get; set; }

    }
}
