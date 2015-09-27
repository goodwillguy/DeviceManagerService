using Tz.Common.DataModel;
using Tz.Common.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tz.Locker.DataModel
{
    [Table("LockerOfflineReason")]
    public class LockerOfflineReason :Base
    {
        [Key]
        public Guid LockerOfflineReasonId { get; set; }
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
