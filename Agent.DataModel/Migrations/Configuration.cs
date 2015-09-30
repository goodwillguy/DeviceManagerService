namespace Tz.Agent.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Tz.Common.DataModel.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Tz.Agent.DataModel.AgentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CodeGenerator = new SkipReadonlyEntityCodeMigration();
        }

        protected override void Seed(Tz.Agent.DataModel.AgentDbContext context)
        {
            var tzorganization = Guid.Parse("EF0CC820-6A7E-40CD-AA45-82FE7CD9F589");

            var prometheus = Guid.Parse("02ACDD4E-87D7-470B-B7C1-B6B3C7FABF79");

            var propertyPromentusSydney = Guid.Parse("1D4B448B-4E69-4ECA-A06E-E7F85256C920");

            var propertyTzSydney = Guid.Parse("0ABAA1CF-C482-4E89-A0E9-BF232F7D97C3");

            var tzAgent = Guid.Parse("3464630D-4814-4AB7-870C-B7F429AD9EDB");

            var tzPrometheus = Guid.Parse("6A638CA6-EFD7-40B2-9FA6-86F129BD0382");


            context.Agents.AddOrUpdate(ag => ag.AgentId, new Entity.Agent
            {
                AgentId = tzAgent,
                EmailAddress="test@gmail.com",
                FirstName="tzAgent",
                LastName="Test",
                IsDisabled=false,
                OrganisationId=tzorganization,
                Username="tzAgent",
                SignInPin="123456"
                
                
            });

            context.Agents.AddOrUpdate(ag => ag.AgentId, new Entity.Agent
            {
                AgentId = tzPrometheus,
                EmailAddress = "pormetheus@gmail.com",
                FirstName = "tzPrmetheus",
                LastName = "Test",
                IsDisabled = false,
                OrganisationId = prometheus,
                Username = "tzPormetheus",
                SignInPin = "123456"
            });


            context.AgentToProperties.AddOrUpdate(agProp => agProp.AgentToPropertyId, new Entity.AgentToProperty
            {
                AgentId=tzAgent,
                BuildingPropertyId=propertyTzSydney
            });

            context.AgentToProperties.AddOrUpdate(agProp => agProp.AgentToPropertyId, new Entity.AgentToProperty
            {
                AgentId = tzPrometheus,
                BuildingPropertyId = propertyPromentusSydney
            });

            context.AgentToCards.AddOrUpdate(agCard => agCard.AgentId, new Entity.AgentToCard
            {
                AgentId = tzAgent,
                CardNumber = "2973-0057922",
                EffectiveFrom = DateTime.Now,
                IsLocked = false
            });

            context.AgentToCards.AddOrUpdate(agCard => agCard.AgentId, new Entity.AgentToCard
            {
                AgentId = tzPrometheus,
                CardNumber = "654321",
                EffectiveFrom = DateTime.Now,
                IsLocked = false
            });

            context.SaveChanges();
        }
    }
}

