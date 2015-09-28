using Tz.Common.DataModel;
using Tz.Resident.DataModel.Entitty;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Resident.DataModel.Migrations;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using Tz.Common.DataModel.Interface;

namespace Tz.Resident.DataModel
{
    public class ResidentDbContext : CustomDbContext
    {

        public ResidentDbContext(string connectionString) : base(connectionString)
        {

        }

        public ResidentDbContext() : base("name=Default")
        {
        }

        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<BuildingPropertyView> Properties { get; set; }

        public virtual DbSet<LockerBankView> LockerBanks { get; set; }

    }
}
