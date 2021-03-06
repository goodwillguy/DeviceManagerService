﻿using Tz.Locker.Common.Interface;
using Tz.LockerBank.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Locker.ApplicationService
{
    public class LockerDeviceManagerApplicationService : ILockerDeviceManagerApplicationServices
    {
        private readonly ILockerBankChannelFactory _lockerBankChannelFactory;
        private readonly ILockerRepository _lockerRepository;

        public LockerDeviceManagerApplicationService(ILockerRepository lockerRepository, ILockerBankChannelFactory lockerBankChannelFactory)
        {
            _lockerRepository = lockerRepository;
            _lockerBankChannelFactory = lockerBankChannelFactory;
        }
        public void OpenLocker(Guid lockerBankId, Guid lockerId)
        {
            var lockerBankAndDeviceInfo=_lockerRepository.GetDeviceSerialNumberForLocker(lockerBankId, lockerId);

            var channel=_lockerBankChannelFactory.CreateChannel<IDeviceManagerService>(lockerBankAndDeviceInfo.LockerBankIpAddress);

            var devices=channel.GetAllDevices();

            channel.Open(new LockerBank.Common.Dto.OpenDeviceDto { SerialNumber = lockerBankAndDeviceInfo.DeviceSerialNumber });

        }

    }
}
