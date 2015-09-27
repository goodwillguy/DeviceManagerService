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

namespace Tz.Resident.DataModel
{
    public class ResidentDbContext : CustomDbContext
    {
        public ResidentDbContext(string connectionString) : base(connectionString)
        {
        }

        public ResidentDbContext():base("name=Default")
        {
        }

        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<BuildingPropertyView> Properties { get; set; }

        public virtual DbSet<LockerBankView> LockerBanks { get; set; }

        public override void InitializeDb()
        {
           /* var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);

            var scriptor = new MigratorScriptingDecorator(migrator);
            var script = scriptor.ScriptUpdate(sourceMigration: null, targetMigration: null);
            Console.WriteLine(script);

            migrator.Update();

            var pending = migrator.GetPendingMigrations();

            Console.ReadLine();*/
        }
    }
}
