using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Parcel.DataModel.ParcelEnitities
{
    [ReadonlyTable]
    public class LockerBankView
    {

        public Guid LockerBankId { get; set; }

        public Guid PropertyId { get; set; }

        public string LockerBankCode { get; set; }


    }
}
