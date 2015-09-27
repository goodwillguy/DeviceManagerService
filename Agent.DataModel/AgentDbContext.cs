using Tz.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Agent.DataModel.Migrations;
using Tz.Agent.DataModel.Entity;

namespace Tz.Agent.DataModel
{
    public class AgentDbContext : CustomDbContext
    {
        public AgentDbContext():base("name=Default")
        {
        }

        public AgentDbContext(string connectionString) : base(connectionString)
        {

        }

        public virtual DbSet<Entity.Agent> Agents { get; set; }
        public virtual DbSet<AgentToProperty> AgentToProperties { get; set; }
        public virtual DbSet<AgentToCard> AgentToCards { get; set; }

        public virtual DbSet<LockerBankView> LockerBank { get; set; }

        public override void InitializeDb()
        {
            Agents.ToList();
        }
    }
}
