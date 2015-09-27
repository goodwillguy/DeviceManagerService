using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.Values.Enums;
using Tz.Locker.DataModel;
using Tz.Locker.Common.Interface;

namespace Tz.Locker.ApplicationService
{
    public class LockerApplicationService : ILockerApplicationService
    {
        private readonly ILockerRepository _lockerRepository;

        public LockerApplicationService(ILockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
        }

        public Guid? GetAvailableLocker(Guid lockerBankId, Size lockerSize)
        {
            Guid? availableLockerId = null;

            var lockersInLockerBank = _lockerRepository.GetAllLockers(lockerBankId);


            availableLockerId = lockersInLockerBank
                                .Where(locker => locker.Size >= lockerSize && locker.State == LockerState.Available)
                                .Select(locker => locker.LockerId)
                                .FirstOrDefault();

            return availableLockerId;
        }

        public Guid? GetAvailableLocker(string lockerBankCode, Size lockerSize)
        {
            var lockerBankId = _lockerRepository.GetLockerBankByCode(lockerBankCode);

            if (lockerBankId == null)
            {
                throw new ApplicationException("Cannot find locker bank");
            }

            return GetAvailableLocker(lockerBankId.Value, lockerSize);

        }

        public Guid? GetLockerBankForLockerBankCode(string lockerBankCode)
        {
            return _lockerRepository.GetLockerBankByCode(lockerBankCode);
        }
    }
}
