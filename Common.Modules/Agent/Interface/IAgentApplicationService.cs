using Common.Modules.Agent.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modules.Agent.Interface
{
    public interface IAgentApplicationService
    {
        string GetTokenForAgent(string lockerBankCode,string agentSignInUserName, string agentPin);

        string GetTokenForAgent(string lockerBankCode, string cardNumber);

        UserDto GetAgentDetails(string agentSignInUserName);


    }
}
