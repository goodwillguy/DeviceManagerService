using Tz.Common.DataModel;
using Tz.Locker.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Locker.DataModel
{
    public class LockerDbContext:CustomDbContext
    {
        public LockerDbContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<Locker> Lockers { get; set; }

        public virtual DbSet<Device> Devices { get; set; }

        public virtual DbSet<LockerBank> LockerBanks { get; set; }
        public virtual DbSet<LockerOfflineReason> LockersOfflineReasons { get; set; }
        public virtual DbSet<PropertyView> Properties { get; set; }

        public virtual DbSet<ParcelView> Parcels { get; set; }

        public virtual DbSet<LockerToDevice> LockerToDevices { get; set; }
    }
}
