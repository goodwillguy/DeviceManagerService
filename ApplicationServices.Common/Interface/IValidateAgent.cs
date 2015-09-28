using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Agent.Common.Dto;

namespace Tz.ApplicationServices.Common.Interface
{
    public interface IValidateAgent
    {
        bool IsAgentAuthorised(string lockerBankCode, string agentUserName, string agentPassword);

        AgentDto GetAuthorisedAgent(string lockerBankCode, string agentUserName, string agentPassword);

        AgentDto GetAuthorisedAgent(string lockerBankCode, string agentCard);

    }
}
