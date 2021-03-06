﻿using Tz.Resident.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Resident.Common.Dto;

namespace Tz.Resident.ApplicationServices
{
    public class ResidentApplicationServices : IResidentApplicationService
    {
        private readonly IResidentRepository _residentRepository;

        public ResidentApplicationServices(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }
        public IEnumerable<ResidentDto> GetAllResidents(Guid lockerBankId)
        {
            return _residentRepository.GetResidentByName(lockerBankId, string.Empty);
        }
    }
}
