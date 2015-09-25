using Tz.Resident.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Resident.Common.Interface
{
    public interface IResidentApplicationService
    {
        IEnumerable<ResidentDto> GetAllResidents(Guid lockerBankId);

    }
}
