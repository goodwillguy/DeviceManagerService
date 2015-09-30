using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Agent.Common.Interface;
using Tz.ApplicationServices.Common.Interface;
using Tz.Locker.Common.Interface;

namespace Tz.AgentValidation
{
    public class AgentWorkFlowServices : IValidateAgent
    {
        private readonly IAgentApplicationServices _agentService;
        private readonly ILockerApplicationService _lockerService;

        public AgentWorkFlowServices(IAgentApplicationServices agentService, ILockerApplicationService lockerService)
        {
            _agentService = agentService;
            _lockerService = lockerService;
        }
        public Tz.Agent.Common.Dto.AgentDto GetAuthorisedAgent(string lockerBankCode, string agentCard)
        {
            var lockerBankId = _lockerService.GetLockerBankForLockerBankCode(lockerBankCode);

            if (lockerBankId == null || !lockerBankId.HasValue || lockerBankId == Guid.Empty)
            {
                throw new ApplicationException("Locker bank code invalid");
            }



            return _agentService.GetAgent(lockerBankId.Value, agentCard);
        }

        public Tz.Agent.Common.Dto.AgentDto GetAuthorisedAgent(string lockerBankCode, string agentUserName, string agentPassword)
        {
            var lockerId = _lockerService.GetLockerBankForLockerBankCode(lockerBankCode);

            if (lockerId == null)
            {
                new ApplicationException("No locker bank available");
            }

            return _agentService.GetAgent(lockerId.Value, agentUserName, agentPassword);
        }

        public bool IsAgentAuthorised(string lockerBankCode, string agentUserName, string agentPassword)
        {
            throw new NotImplementedException();
        }
    }
}
