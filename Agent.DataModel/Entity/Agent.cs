using Tz.Agent.DataModel.Entity;
using Tz.Common.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Agent.DataModel
{
    public class Agent : Base, IAuditable
    {
        [Key]
        public Guid AgentId { get; set; }

        public string SignInPin { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string MobileNumber { get; set; }

        public Guid OrganisationId { get; set; }

        public virtual List<AgentToCard> AgentCards { get; set; }

        public virtual List<AgentToProperty> Properties { get; set; }
        public bool IsDisabled { get; internal set; }
    }
}
