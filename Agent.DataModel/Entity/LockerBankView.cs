using Common.DataModel;
using Common.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.DataModel
{
    [ReadonlyTable]
    public class LockerBankView
    {

        public Guid LockerBankId { get; set; }

        public Guid PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual PropertyView Property { get; set; }

    }
}
