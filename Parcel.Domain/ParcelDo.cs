using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Domain
{
    public class ParcelDo
    {
        public Guid ParcelId { get; private set; }
        public string ConsignmentNo { get; private set; }
        public Guid RecipientId { get; private set; }

        public ParcelDo(Guid parcelId,string consignmentNo,Guid recipientId)
        {
            ParcelId = parcelId;
            ConsignmentNo = consignmentNo;
            RecipientId = recipientId;
        }




        public void DropOff(Guid agentId)
        {

        }

    }
}
