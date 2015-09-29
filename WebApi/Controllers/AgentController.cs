using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Tz.Agent.Common.Dto;
using Tz.ApplicationServices.Common.Interface;

namespace WebApi.Controllers
{
    [EnableCors("*","*","*")]
    public class AgentController:ApiController
    {
        private readonly IValidateAgent _validateAgent;

        public AgentController(IValidateAgent validateAgent)
        {
            _validateAgent = validateAgent;
        }

        [Route("api/agent/agentbyUserName")]
        [HttpPost]
        public AgentDto GetAgentForUserName(string lockerBankCode, string agentUserName, string agentPassword)
        {
            return _validateAgent.GetAuthorisedAgent(lockerBankCode, agentUserName, agentPassword);
        }

        [Route("api/agent/agentByCard")]
        [HttpPost]
        public AgentDto AgentForCard(string lockerBankCode, string cardNumber)
        {
            return _validateAgent.GetAuthorisedAgent(lockerBankCode, cardNumber);
        }

    }
}
