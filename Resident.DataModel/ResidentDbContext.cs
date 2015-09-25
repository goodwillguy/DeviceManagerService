using Common.DataModel;
using Resident.DataModel.Entitty;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resident.DataModel
{
    public class ResidentDbContext : CustomDbContext
    {
        public ResidentDbContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<PropertyView> Properties { get; set; }

        public virtual DbSet<LockerBankView> LockerBanks { get; set; }
    }
}
