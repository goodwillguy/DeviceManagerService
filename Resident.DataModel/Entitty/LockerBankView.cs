using Common.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resident.DataModel.Entitty
{
    [ReadonlyTable]
    public class LockerBankView
    {
        public Guid LockerBankId { get; set; }

        public Guid PropertyId { get; set; }

        public string LockerBankCode { get; set; }

        public virtual PropertyView Property { get; set; }
    }
}
