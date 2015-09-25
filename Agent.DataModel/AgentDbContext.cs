using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.DataModel
{
    public class AgentDbContext : CustomDbContext
    {
        public AgentDbContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }

        public virtual DbSet<LockerBankView> LockerBank { get; set; }


    }
}
