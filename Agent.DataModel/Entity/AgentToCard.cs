using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.DataModel.Entity
{
    public class AgentToCard :Base
    {
        public string CardNumber { get; set; }

        [Required]
        public Guid AgentId { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }

        public bool IsLocked { get; set; }
    }
}
