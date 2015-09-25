using Tz.Agent.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Agent.Common.Dto;

namespace Tz.Agent.ApplicationServices
{
    public class AgentApplicationService : IAgentApplicationServices
    {
        private readonly IAgentRepository _agentRepository;

        public AgentApplicationService(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }
        public AgentDto GetAgent(Guid lockerBankId, string cardNumber)
        {
            return _agentRepository.GetAgentByCardNo(lockerBankId, cardNumber);
        }

        public AgentDto GetAgent(Guid lockerBankId, string agentUserName, string agentPin)
        {
            var isAgentValid = _agentRepository.IsAgentAuthorised(lockerBankId, agentUserName, agentPin);
            if (isAgentValid)
            {
                return _agentRepository.GetAgentByUserName(lockerBankId, agentUserName);
            }
            return null;
        }
    }
}
