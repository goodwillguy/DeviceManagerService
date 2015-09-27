using Tz.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tz.Parcel.DataModel.ParcelEnitities
{
    [ReadonlyTable]
    [Table("LockerBank")]
    public class LockerBankView
    {
        [Key]

        public Guid LockerBankId { get; set; }

        public Guid BuildingPropertyId { get; set; }

        public string LockerBankCode { get; set; }


    }
}
