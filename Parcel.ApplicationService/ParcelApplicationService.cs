using Common.Modules.Interface;
using Common.Values;
using Common.Values.Enums;
using Tz.Locker.Common.Interface;
using Tz.Parcel.Common.Dto;
using Tz.Parcel.Common.Interface;
using System;
using System.Collections.Generic;

namespace Tz.Parcel.ApplicationService
{
    public class ParcelApplicationService : IDropOffParcel
    {
        private readonly IDateTime _dateTime;
        private readonly ILockerApplicationService _lockerService;
        private readonly IParcelRepository _parcelRepository;

        public ParcelApplicationService(ILockerApplicationService lockerService, IParcelRepository parcelRepository,IDateTime dateTime)
        {
            _lockerService = lockerService;
            _parcelRepository = parcelRepository;
            _dateTime = dateTime;
        }
        public bool DropOffParcel(Guid operatorId,Guid lockerBankId, Size parcelSize, string consignmentNumber, Guid agentDropOffId, Guid residentId)
        {
            bool isDropoffSuccess = false;

            var availableLocker = _lockerService.GetAvailableLocker(lockerBankId, parcelSize);


            var parcel = _parcelRepository.GetParcelByConsignmentNumber(lockerBankId, consignmentNumber);
            //var hasConsignmentNo =context.Parcels.Any(parcel => parcel.ConsignmentNumber.ToLower() == consignmentNumber.ToLower());

            if (parcel != null)
            {
                throw new ApplicationException("This parcel already exists in the db");
            }

            var exipryTime = DateTime.Now.AddDays(3);

            var parcelId = Guid.NewGuid();

            var parcelTransaction = new ParcelTransactionDto
            {
                ParcelTransactionId = Guid.NewGuid(),
                ParcelId = parcelId,
                DropOffAgentId = agentDropOffId,
                DropoffTime = DateTime.Now,
                TransactionState = TransactionState.Dropoff,
                CreateUserId=operatorId,
                CreationTime=_dateTime.GetCurrentDate(),

            };

            var newParcel = new ParcelDto
            {
                ConsignmentNumber = consignmentNumber,
                IsExpired = false,
                LockerBankId = lockerBankId,
                ParcelId = parcelId,
                Size = parcelSize,
                SenderId = agentDropOffId,
                RecipientId = residentId,
                ExpiryTime = exipryTime,
                LockerId = availableLocker.Value,
                ParcelTransactions = new List<ParcelTransactionDto> { parcelTransaction }

            };

            _parcelRepository.AddNewParcel(newParcel);

            return isDropoffSuccess;
        }

    }
}
