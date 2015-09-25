using Agent.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.Common.Interface
{
    public interface IAgentApplicationServices
    {
        AgentDto GetAgent(Guid lockerBankId, string agentUserName, string agentPin);

        AgentDto GetAgent(Guid lockerBankId, string cardNumber);
    }
}
