using Tz.Common.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Agent.DataModel.Migrations;

namespace Tz.Agent.DataModel
{
    public class AgentDbContext : CustomDbContext
    {
        public AgentDbContext()
        {
        }

        public AgentDbContext(string connectionString) : base(connectionString)
        {

        }

        public virtual DbSet<Agent> Agents { get; set; }

        public virtual DbSet<LockerBankView> LockerBank { get; set; }

        public override void InitializeDb()
        {
            Agents.ToList();
        }
    }
}
