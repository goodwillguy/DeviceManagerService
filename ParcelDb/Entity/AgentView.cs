using Tz.Common.DataModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tz.Parcel.DataModel.Entity
{
    [ReadonlyTable]
    [Table("Agent")]
    public class AgentView
    {
        [Key]
        public Guid AgentId { get; set; }

        public Guid OrganisationId { get; set; }
    }
}