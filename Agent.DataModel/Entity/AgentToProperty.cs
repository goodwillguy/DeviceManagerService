using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Agent.DataModel
{
    public class AgentToProperty
    {
        public Guid AgentId { get; set; }

        public Guid PropertyId { get; set; }


        [ForeignKey("PropertyId")]
        public virtual PropertyView Property { get; set; }
    }
}
