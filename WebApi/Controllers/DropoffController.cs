using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tz.ApplicationServices.Common.Interface;

namespace WebApi.Controllers
{
    public class DropoffController : ApiController
    {
        private readonly IDropOffEvent _dropoffService;

        public DropoffController(IDropOffEvent dropoffService)
        {
            _dropoffService = dropoffService;
        }

        [Route("api/parcel/dropoffParcel")]
        [HttpPost]
        public bool DropOffParcel(DropOffDto dropOff)
        {
            _dropoffService.DoDropOff(dropOff.LockerBankCode, Guid.Parse(dropOff.ResidentId), Tz.Common.Values.Enums.Size.Small, dropOff.ParcelConsignmentNumber, Guid.Parse(dropOff.OperatorId), Guid.Parse(dropOff.AgentId));

            return true;
        }
    }
}
