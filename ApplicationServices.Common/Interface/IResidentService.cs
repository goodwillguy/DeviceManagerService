using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Resident.Common.Dto;

namespace Tz.ApplicationServices.Common.Interface
{
    public interface IResidentService
    {
        IEnumerable<ResidentDto> GetResidents(string lockerBankCode, string filterText);
    }
}
