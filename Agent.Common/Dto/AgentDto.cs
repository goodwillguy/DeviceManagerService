using Common.Values;
using System;

namespace Tz.Agent.Common.Dto
{
    public class AgentDto:Base
    {
        public Guid AgentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public Guid OrganisationId { get; set; }
    }
}