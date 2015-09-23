using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Parcel.DataModel.ParcelEnitities;
namespace Tz.Parcel.DataModel
{
    public class ParcelDbContext : CustomDbContext
    {
        public ParcelDbContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<ParcelEnitities.Parcel> Parcels { get; set; }

        public virtual DbSet<ParcelEnitities.ParcelTransaction> ParcelTransactions { get; set; }

        public virtual DbSet<ParcelEnitities.LockerView> Lockers { get; set; }

    }
}
