using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Tz.Parcel.DataModel.Entity;
using Tz.Tz.Parcel.DataModel.ParcelEnitities;
namespace Tz.Tz.Parcel.DataModel
{
    public class ParcelDbContext : CustomDbContext
    {
        public ParcelDbContext(string connectionString) : base(connectionString)
        {

        }

        public virtual DbSet<ParcelEnitities.Parcel> Parcels { get; set; }

        public virtual DbSet<ParcelTransaction> ParcelTransactions { get; set; }

        public virtual DbSet<LockerView> Lockers { get; set; }

        public virtual DbSet<LockerBankView> LockerBanks { get; set; }

        public virtual DbSet<AgentView> Agents { get; set; }

    }
}
