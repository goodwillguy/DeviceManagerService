using Tz.Common.DataModel;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tz.Tz.Parcel.DataModel.Entity
{
    [ReadonlyTable]
    [Table("Agent")]
    public class AgentView
    {
        public Guid AgentId { get; set; }

        public Guid OrganisationId { get; set; }
    }
}