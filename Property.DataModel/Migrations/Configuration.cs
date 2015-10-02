namespace Tz.Property.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tz.Common.DataModel.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Tz.Property.DataModel.PropertyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            CodeGenerator = new SkipReadonlyEntityCodeMigration();
        }

        protected override void Seed(Tz.Property.DataModel.PropertyDbContext context)
        {
            var tzorganization = Guid.Parse("EF0CC820-6A7E-40CD-AA45-82FE7CD9F589");

            var prometheus = Guid.Parse("02ACDD4E-87D7-470B-B7C1-B6B3C7FABF79");

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
            if (!context.Organisations.Any())
            {
                context.Organisations.AddOrUpdate(
                        org => org.OrganisationId, new Entity.Organisation
                        {
                            OrganisationId = tzorganization,
                            Code = "Tz",
                            Description = "TzOrganization"
                        });

                context.Organisations.AddOrUpdate(
                       org => org.OrganisationId, new Entity.Organisation
                       {
                           OrganisationId = prometheus,
                           Code = "Prometheus",
                           Description = "Prometheus Organization"
                       });

            }

            if (!context.BuildingProperties.Any())
            {
                context.BuildingProperties.AddOrUpdate(prop =>
                prop.BuildingPropertyId, new Entity.BuildingProperty
                {
                    BuildingPropertyId = Guid.Parse("0ABAA1CF-C482-4E89-A0E9-BF232F7D97C3"),
                    Code = "TzSydney",
                    Description = "Tz at Sydney"

                });


                context.BuildingProperties.AddOrUpdate(prop =>
               prop.BuildingPropertyId, new Entity.BuildingProperty
               {
                   BuildingPropertyId = Guid.Parse("1D4B448B-4E69-4ECA-A06E-E7F85256C920"),
                   Code = "PrometheusSydney",
                   Description = "Prometheus at Sydney"
               });


                context.OrganisationToProperty.AddOrUpdate(org => org.OrganisationToPropertyId, new Entity.OrganisationToProperty
                {
                    OrganisationId = tzorganization,
                    BuildingPropertyId = Guid.Parse("0ABAA1CF-C482-4E89-A0E9-BF232F7D97C3")
                });

                context.OrganisationToProperty.AddOrUpdate(org => org.OrganisationToPropertyId, new Entity.OrganisationToProperty
                {
                    OrganisationId = prometheus,
                    BuildingPropertyId = Guid.Parse("1D4B448B-4E69-4ECA-A06E-E7F85256C920")
                });

            }
            context.SaveChanges();
        }
    }
}
