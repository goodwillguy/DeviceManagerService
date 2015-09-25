using Tz.Common.DataModel;
using Tz.Common.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tz.Agent.DataModel
{
    [ReadonlyTable]
    [Table("LockerBank")]
    public class LockerBankView
    {
        [Key]
        public Guid LockerBankId { get; set; }

        public Guid PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual PropertyView Property { get; set; }

    }
}
