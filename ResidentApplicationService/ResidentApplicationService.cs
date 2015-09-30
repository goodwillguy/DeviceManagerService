using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.ApplicationServices.Common.Interface;
using Tz.Locker.Common.Interface;
using Tz.Resident.Common.Dto;
using Tz.Resident.Common.Interface;

namespace Tz.Resident.ApplicationService
{
    public class ResidentWorkService : IResidentService
    {
        private readonly ILockerApplicationService _lockerService;
        private readonly IResidentApplicationService _residentService;

        public ResidentWorkService(ILockerApplicationService lockerService, IResidentApplicationService residentService)
        {
            _lockerService = lockerService;
            _residentService = residentService;
        }
        public IEnumerable<ResidentDto> GetResidents(string lockerBankCode, string filterText)
        {
            var lockerBankId=_lockerService.GetLockerBankForLockerBankCode(lockerBankCode);

            if (lockerBankId == null || !lockerBankId.HasValue || lockerBankId == Guid.Empty)
            {
                throw new ApplicationException("Locker bank code invalid");
            }

            return _residentService.GetAllResidents(lockerBankId.Value);

        }
    }
}
