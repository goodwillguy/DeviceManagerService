using Tz.Common.Values.Enums;
using System;
using Tz.Locker.Common.Dto;
using System.Collections.Generic;

namespace Tz.Locker.Common.Interface
{
    public interface ILockerApplicationService
    {
        LockerDto GetAvailableLocker(Guid lockerBankId, Size lockerSize);

        LockerDto GetAvailableLocker(string lockerBankCode, Size lockerSize);

        Guid? GetLockerBankForLockerBankCode(string lockerBankCode);

        List<LockerDto> GetAllLockers(Guid lockerBankId);

        bool IsLockerAvailable(Guid lockerBankId, Guid lockerId);
        void UpdateLockerAsOccupied(Guid lockerBankId, Guid lockerId);
        //Locker GetAvailableLocker(string lockerBankId, Size lockerSize);
    }

}
