using Common.Values.Enums;
using System;

namespace Tz.Locker.Common.Interface
{
    public interface ILockerApplicationService
    {
        Guid? GetAvailableLocker(Guid lockerBankId, Size lockerSize);

        //Locker GetAvailableLocker(string lockerBankId, Size lockerSize);
    }

}
