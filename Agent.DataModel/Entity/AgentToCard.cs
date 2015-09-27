using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.Values;

namespace Tz.Agent.DataModel.Entity
{
    [Table("AgentToCard")]
    public class AgentToCard :Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AgentToCardId { get; set; }
        public string CardNumber { get; set; }

        [Required]
        public Guid AgentId { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public DateTime? EffectiveTo { get; set; }

        public bool IsLocked { get; set; }

        [ForeignKey("AgentId")]
        public virtual Agent Agent { get; set; }
    }
}
