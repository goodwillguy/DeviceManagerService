﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Values.Enums;
using Locker.DataModel;
using Locker.Common.Interface;

namespace Locker.ApplicationService
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
    }
}