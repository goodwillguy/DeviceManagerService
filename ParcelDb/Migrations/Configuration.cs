namespace Tz.Parcel.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tz.Common.DataModel.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Tz.Parcel.DataModel.ParcelDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CodeGenerator = new SkipReadonlyEntityCodeMigration();
        }

        protected override void Seed(Tz.Parcel.DataModel.ParcelDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
