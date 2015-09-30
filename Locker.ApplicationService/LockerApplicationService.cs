using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.Values.Enums;
using Tz.Locker.DataModel;
using Tz.Locker.Common.Interface;
using Tz.Locker.Common.Dto;

namespace Tz.Locker.ApplicationService
{
    public class LockerApplicationService : ILockerApplicationService
    {
        private readonly ILockerRepository _lockerRepository;

        public LockerApplicationService(ILockerRepository lockerRepository)
        {
            _lockerRepository = lockerRepository;
        }

        public LockerDto GetAvailableLocker(Guid lockerBankId, Size lockerSize)
        {

            var lockersInLockerBank = _lockerRepository.GetAllLockers(lockerBankId);


            var availableLocker = lockersInLockerBank
                                .FirstOrDefault(locker => locker.Size >= lockerSize && locker.State == LockerState.Available);

            return availableLocker;
        }

        public LockerDto GetAvailableLocker(string lockerBankCode, Size lockerSize)
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

        public List<LockerDto> GetAllLockers(Guid lockerBankId)
        {

            return _lockerRepository.GetAllLockers(lockerBankId);
        }

        public bool IsLockerAvailable(Guid lockerBankId, Guid lockerId)
        {
            return _lockerRepository.IsLockerAvailable(lockerBankId, lockerId);
        }

        public void UpdateLockerAsOccupied(Guid lockerBankId, Guid lockerId)
        {
            _lockerRepository.UpdateLockerAsOccupied(lockerBankId, lockerId);
        }
    }
}
