using System;
using Tz.ApplicationServices.Common.Interface;
using Tz.Common.Values.Enums;
using Tz.Locker.Common.Interface;
using Tz.Parcel.Common.Interface;

namespace DropOffApplication_service
{
    public class DropOffHandler : IDropOffEvent
    {
        private readonly ILockerApplicationService _lockerApplicationService;
        private readonly ILockerDeviceManagerApplicationServices _lockerManager;
        private readonly IDropOffParcel _parcelApplcationService;

        public DropOffHandler(ILockerApplicationService lockerApplicationService,ILockerDeviceManagerApplicationServices lockerManager,IDropOffParcel parcelApplcationService)
        {
            _lockerApplicationService = lockerApplicationService;
            _lockerManager = lockerManager;
            _parcelApplcationService = parcelApplcationService;
        }
        public void DoDropOff(string lockerBankCode, Guid residentId, Size parcelSize,string consignmentNumber,Guid operatorId,Guid agentDropOffId)
        {
            var lockerBankId=_lockerApplicationService.GetLockerBankForLockerBankCode(lockerBankCode);

            if(lockerBankId==null)
            {
                new ApplicationException("Locker bank code invalid");
            }

            _parcelApplcationService.DropOffParcel(operatorId, lockerBankId.Value, parcelSize, consignmentNumber, agentDropOffId, residentId);

            var parcelInfo=_parcelApplcationService.GetParcelInformation(lockerBankId.Value, consignmentNumber);

            _lockerManager.OpenLocker(lockerBankId.Value, parcelInfo.LockerId.Value);
        }
    }
}
