using Tz.Common.Values.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Parcel.Common.Dto;

namespace Tz.Parcel.Common.Interface
{
    public interface IDropOffParcel
    {
        bool DropOffParcel(Guid operatorId, Guid lockerBankCode, Size lockerSize, string consignmentNumber, Guid agentDropOffId, Guid residentId);

        ParcelDto GetParcelInformation(Guid lockerBankId, string consignmentNumber);
    }
}
