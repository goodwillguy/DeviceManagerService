using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.Values.Enums;
using Tz.Locker.Common.Dto;

namespace Tz.ApplicationServices.Common.Interface
{
    public interface ILockerBankService
    {
        List<LockerDto> GetAllLockers(string lockerBankCode);


        LockerDto GetAvailableLocker(string lockerBankCode, Size parcelSize);
    }
}
