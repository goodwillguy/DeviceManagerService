using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Tz.Agent.Common.Dto;
using Tz.ApplicationServices.Common.Interface;

namespace WebApi.Controllers
{
    public class P
    {
        public string LockerBankCode { get; set; }
        public string CardNumber { get; set; }
    }
    public class AgentController:ApiController
    {
        private readonly IValidateAgent _validateAgent;

        public AgentController(IValidateAgent validateAgent)
        {
            _validateAgent = validateAgent;
        }

        public AgentDto GetAgentForUserName(string lockerBankCode, string agentUserName, string agentPassword)
        {
            return _validateAgent.GetAuthorisedAgent(lockerBankCode, agentUserName, agentPassword);
        }

        [Route("api/agent/agentForCard")]
        [HttpPost]
        //public AgentDto AgentForCard(string LockerBankCode, string CardNumber)
        public AgentDto AgentForCard(P p)
        {
            return _validateAgent.GetAuthorisedAgent(p.LockerBankCode, p.CardNumber);
        }

        [Route("api/agent/test")]
        [HttpPost]
        public bool Test(int id)
        {
            return false;
        }
    }
}
