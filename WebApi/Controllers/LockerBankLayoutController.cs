using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Tz.ApplicationServices.Common;
using Tz.ApplicationServices.Common.Interface;
using Tz.Common.Values.Enums;
using Tz.Locker.Common.Dto;
using WebApi.Dto;
using WebApi.RoutePrefix;

namespace WebApi.Controllers
{
    [ApplicationExceptionFilter]
    [EnableCors("*", "*", "*")]
    public class LockerBankLayoutController : ApiController
    {
        private readonly ILockerBankService _lockerService;

        public LockerBankLayoutController(ILockerBankService lockerService)
        {
            _lockerService = lockerService;
        }

        [Route("api/locker/getLayout")]
        public KeyValuePair<int, List<LockerLayoutDto>>[] GetLockerBankLayout(string lockerBankCode)
        {
            var lockers = _lockerService.GetAllLockers(lockerBankCode);


            var lockerDto = lockers.Select(lo => new LockerLayoutDto
            {
                LockerNumber = lo.LockerNumber,
                Column = lo.Column,
                Size = lo.Size.ToString()
            });

            var list = lockerDto.GroupBy(lo => lo.Column)
                .ToDictionary(gr => gr.Key, gr => gr.ToList());

            return list.ToArray();
        }

        [Route("api/locker/getAvailableLocker")]
        public LockerDataDto GetAvailableLocker(string lockerBankCode, int parcelSize)
        {
            var locker = _lockerService.GetAvailableLocker(lockerBankCode, Size.Small);

            if (locker == null)
            {
                throw new ApplicationException("No lockers available for dropoff");
            }

            return new LockerDataDto { LockerId = locker.LockerId, LockerNumber = locker.LockerNumber,DeviceSerialNumber=locker.DeviceSerialNumber };

        }


    }
}
