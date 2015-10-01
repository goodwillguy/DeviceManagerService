using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Tz.ApplicationServices.Common;
using Tz.ApplicationServices.Common.Interface;
using WebApi.Dto;
using WebApi.RoutePrefix;

namespace WebApi.Controllers
{
    [ApplicationExceptionFilter]
    [EnableCors("*", "*", "*")]
    public class DropoffController : ApiController
    {
        private readonly IDropOffEvent _dropoffService;

        public DropoffController(IDropOffEvent dropoffService)
        {
            _dropoffService = dropoffService;
        }

        [Route("api/parcel/dropoffParcel")]
        [HttpPost]
        public LockerDataDto DropOffParcel(DropOffDto dropOff)
        {
            return _dropoffService.DoDropOff(dropOff.LockerBankCode, Guid.Parse(dropOff.ResidentId), Tz.Common.Values.Enums.Size.Small, dropOff.ParcelConsignmentNumber, Guid.Parse(dropOff.OperatorId), Guid.Parse(dropOff.AgentId),Guid.Parse(dropOff.LockerId));

        }
    }
}
