namespace Tz.Agent.DataModel.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Guid(nullable: false),
                        SignInPin = c.String(),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(),
                        OrganisationId = c.Guid(nullable: false),
                        IsDisabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.AgentToCards",
                c => new
                    {
                        AgentToCardId = c.Guid(nullable: false, identity: true),
                        CardNumber = c.String(),
                        AgentId = c.Guid(nullable: false),
                        EffectiveFrom = c.DateTime(nullable: false),
                        EffectiveTo = c.DateTime(),
                        IsLocked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AgentToCardId)//foreging key parent table dbo.Agents dependent table dbo.AgentToCards
                
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.AgentToProperties",
                c => new
                    {
                        AgentToPropertyId = c.Guid(nullable: false, identity: true),
                        AgentId = c.Guid(nullable: false),
                        BuildingPropertyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AgentToPropertyId)//foreging key parent table dbo.Property dependent table dbo.AgentToProperties
                //foreging key parent table dbo.Agents dependent table dbo.AgentToProperties
                
                .ForeignKey("dbo.Agents", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.BuildingPropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgentToProperties", "AgentId", "dbo.Agents");
            DropForeignKey("dbo.AgentToCards", "AgentId", "dbo.Agents");
            DropIndex("dbo.AgentToProperties", new[] { "BuildingPropertyId" });
            DropIndex("dbo.AgentToProperties", new[] { "AgentId" });
            DropIndex("dbo.AgentToCards", new[] { "AgentId" });
            DropTable("dbo.AgentToProperties");
            DropTable("dbo.AgentToCards");
            DropTable("dbo.Agents");
        }
    }
}
