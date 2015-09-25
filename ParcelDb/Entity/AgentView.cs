using Common.DataModel;
using System;

namespace Tz.Parcel.DataModel.Entity
{
    [ReadonlyTable]
    public class AgentView
    {
        public Guid AgentId { get; set; }

        public Guid OrganisationId { get; set; }
    }
}