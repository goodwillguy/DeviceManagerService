using Tz.Common.Values.Enums;
using System;

namespace Tz.Locker.Common.Interface
{
    public interface ILockerApplicationService
    {
        Guid? GetAvailableLocker(Guid lockerBankId, Size lockerSize);

        Guid? GetAvailableLocker(string lockerBankCode, Size lockerSize);

        Guid? GetLockerBankForLockerBankCode(string lockerBankCode);
        //Locker GetAvailableLocker(string lockerBankId, Size lockerSize);
    }

}
