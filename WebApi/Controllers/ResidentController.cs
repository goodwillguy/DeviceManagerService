using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Tz.ApplicationServices.Common.Interface;
using Tz.Resident.Common.Dto;

namespace WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ResidentController:ApiController
    {
        private readonly IResidentService _residentService;

        public ResidentController(IResidentService residentService)
        {
            _residentService = residentService;
        }

        [Route("api/resident/GetResidents")]
        [HttpGet]
        public IEnumerable<ResidentDto> GetAllResidents(string lockerBankCode)
        {
            return _residentService.GetResidents(lockerBankCode, string.Empty);
        }


    }
}
