using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.ApplicationServices.Common.Interface;
using Tz.Common.Values.Enums;
using Tz.Locker.Common.Dto;
using Tz.Locker.Common.Interface;

namespace Tz.LockerBank.ApplicationService
{
    public class LockerService : ILockerBankService
    {
        private readonly ILockerApplicationService _lockerDomainSvc;

        public LockerService(ILockerApplicationService lockerDomainSvc)
        {
            _lockerDomainSvc = lockerDomainSvc;
        }
        public List<LockerDto> GetAllLockers(string lockerBankCode)
        {
            var lockerId = _lockerDomainSvc.GetLockerBankForLockerBankCode(lockerBankCode);

            return _lockerDomainSvc.GetAllLockers(lockerId.Value);

        }

        public LockerDto GetAvailableLocker(string lockerBankCode, Size parcelSize)
        {
            var lockerId = _lockerDomainSvc.GetLockerBankForLockerBankCode(lockerBankCode);

             return _lockerDomainSvc.GetAvailableLocker(lockerId.Value, parcelSize);
        }
    }
}
