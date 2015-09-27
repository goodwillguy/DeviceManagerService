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
                "dbo.Agent",
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
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.AgentToCard",
                c => new
                    {
                        AgentToCardId = c.Guid(nullable: false, identity: true),
                        CardNumber = c.String(),
                        AgentId = c.Guid(nullable: false),
                        EffectiveFrom = c.DateTime(nullable: false),
                        EffectiveTo = c.DateTime(),
                        IsLocked = c.Boolean(nullable: false),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.AgentToCardId)//foreging key parent table dbo.Agent dependent table dbo.AgentToCard
                
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)
                .Index(t => t.AgentId);
            
            CreateTable(
                "dbo.AgentToProperty",
                c => new
                    {
                        AgentToPropertyId = c.Guid(nullable: false, identity: true),
                        AgentId = c.Guid(nullable: false),
                        BuildingPropertyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AgentToPropertyId)//foreging key parent table dbo.Agent dependent table dbo.AgentToProperty
                
                .ForeignKey("dbo.Agent", t => t.AgentId, cascadeDelete: true)//foreging key parent table dbo.BuildingProperty dependent table dbo.AgentToProperty
                
                .ForeignKey("dbo.BuildingProperty", t => t.BuildingPropertyId, cascadeDelete: true)
                .Index(t => t.AgentId)
                .Index(t => t.BuildingPropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgentToProperty", "AgentId", "dbo.Agent");
            DropForeignKey("dbo.AgentToCard", "AgentId", "dbo.Agent");
            DropIndex("dbo.AgentToProperty", new[] { "BuildingPropertyId" });
            DropIndex("dbo.AgentToProperty", new[] { "AgentId" });
            DropIndex("dbo.AgentToCard", new[] { "AgentId" });
            DropTable("dbo.AgentToProperty");
            DropTable("dbo.AgentToCard");
            DropTable("dbo.Agent");
        }
    }
}
