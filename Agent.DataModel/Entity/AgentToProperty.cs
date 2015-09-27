using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Agent.DataModel.Entity
{
    [Table("AgentToProperty")]
    public class AgentToProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AgentToPropertyId { get; set; }
        public Guid AgentId { get; set; }

        public Guid BuildingPropertyId { get; set; }


        [ForeignKey("BuildingPropertyId")]
        public virtual BuildingPropertyView BuildingProperty { get; set; }

        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }
    }
}
