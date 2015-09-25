using Tz.Agent.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Agent.Common.Interface
{
    public interface IAgentRepository
    {
        AgentDto GetAgentById(Guid lockerBankId, Guid agentId);

        AgentDto GetAgentByCardNo(Guid lockerBankId, string cardNumber);

        AgentDto GetAgentByUserName(Guid lockerBankId, string agentUserName);

        bool IsAgentAuthorised(Guid lockerBankId, string cardNumber);
        bool IsAgentAuthorised(Guid lockerBankId, string agentUserName, string agentPassword);
    }
}
