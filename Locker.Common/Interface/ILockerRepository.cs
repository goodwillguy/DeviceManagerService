using Tz.Locker.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Locker.Common.Interface
{
    public interface ILockerRepository
    {
        LockerDto GetLockerById(string lockerBankCode,Guid lockerId);

        Guid? GetLockerBankByCode(string lockerBankCode);

        LockerDto GetLockerById(Guid lockerBankId, Guid lockerId);

        List<LockerDto> GetAllLockers(Guid lockerBankId);

        LockerAndDeviceDto GetDeviceSerialNumberForLocker(Guid lockerBankId, Guid lockerId);
        bool IsLockerAvailable(Guid lockerBankId, Guid lockerId);
        void UpdateLockerAsOccupied(Guid lockerBankId, Guid lockerId);
    }
}
