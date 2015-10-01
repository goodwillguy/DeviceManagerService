namespace Tz.Resident.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tz.Common.DataModel.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Tz.Resident.DataModel.ResidentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CodeGenerator = new SkipReadonlyEntityCodeMigration();
        }

        protected override void Seed(Tz.Resident.DataModel.ResidentDbContext context)
        {
            var residentSenthil = Guid.NewGuid();
            var residentLeon = Guid.NewGuid();
            var residentSam = Guid.NewGuid();

            var propertyPromentusSydney = Guid.Parse("1D4B448B-4E69-4ECA-A06E-E7F85256C920");

            var propertyTzSydney = Guid.Parse("0ABAA1CF-C482-4E89-A0E9-BF232F7D97C3");


            context.Residents.AddOrUpdate(res => res.ResidentCode, new Resident
            {
                ResidentId = residentSenthil,
                EmailAddress = "goodwillguy@gmail.com",
                FirstName = "senthil kumar",
                IsResidentDisabled = false,
                LastName = "Devadas",
                BuildingPropertyId = propertyPromentusSydney,
                SignInPin = "password",
                Username = "goodwillguy",
                ResidentCode="Pro001"
            });

            context.Residents.AddOrUpdate(res => res.ResidentCode, new Resident
            {
                ResidentId = residentLeon,
                EmailAddress = "Leon@gmail.com",
                FirstName = "Leon",
                IsResidentDisabled = false,
                LastName = "vedanta",
                BuildingPropertyId = propertyTzSydney,
                SignInPin = "password",
                Username = "leon",
                ResidentCode = "Tz001"
            });

            context.Residents.AddOrUpdate(res => res.ResidentCode, new Resident
            {
                ResidentId = residentSam,
                EmailAddress = "sam@gmail.com",
                FirstName = "Sam",
                IsResidentDisabled = false,
                LastName = "Alavi",
                BuildingPropertyId = propertyTzSydney,
                SignInPin = "password",
                Username = "Sam",
                ResidentCode = "Tz002"
            });
        }
    }
}
