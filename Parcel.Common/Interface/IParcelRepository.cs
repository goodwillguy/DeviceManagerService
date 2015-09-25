using Parcel.Common.Dto;
using System;

namespace Parcel.Common.Interface
{
    public interface IParcelRepository
    {
        ParcelDto GetParcelById(Guid lockerBankId, Guid parcelId);

        ParcelDto GetParcelByConsignmentNumber(Guid lockerBankId, string consignmentNo);
        void AddNewParcel(ParcelDto newParcel);
    }
}