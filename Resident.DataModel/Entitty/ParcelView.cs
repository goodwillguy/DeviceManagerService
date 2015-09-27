using Tz.Common.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tz.Resident.DataModel
{
    [ReadonlyTable]
    [Table("Parcel")]
    public class ParcelView 
    {
        [Key]
        public Guid ParcelId { get; set; }

        public string ConsignmentNumber { get; set; }

        public Guid RecipientId { get; set; }
        public Guid LockerBankId { get; set; }

    }
}
