using Common.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resident.DataModel
{
    
    public class ParcelView : IReadonlyEntity
    {
        public Guid ParcelId { get; set; }

        public string ConsignmentNumber { get; set; }

        public Guid RecipientId { get; set; }
        public Guid LockerBankId { get; set; }

    }
}
