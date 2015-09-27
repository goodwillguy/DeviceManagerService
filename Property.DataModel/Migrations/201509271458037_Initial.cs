namespace Tz.Property.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingProperty",
                c => new
                    {
                        BuildingPropertyId = c.Guid(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.BuildingPropertyId);
            
            CreateTable(
                "dbo.Organisation",
                c => new
                    {
                        OrganisationId = c.Guid(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrganisationId);
            
            CreateTable(
                "dbo.OrganisationToProperty",
                c => new
                    {
                        OrganisationToPropertyId = c.Guid(nullable: false, identity: true),
                        OrganisationId = c.Guid(nullable: false),
                        BuildingPropertyId = c.Guid(nullable: false),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.OrganisationToPropertyId)//foreging key parent table dbo.Organisation dependent table dbo.OrganisationToProperty
                
                .ForeignKey("dbo.Organisation", t => t.OrganisationId, cascadeDelete: true)//foreging key parent table dbo.BuildingProperty dependent table dbo.OrganisationToProperty
                
                .ForeignKey("dbo.BuildingProperty", t => t.BuildingPropertyId, cascadeDelete: true)
                .Index(t => t.OrganisationId)
                .Index(t => t.BuildingPropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrganisationToProperty", "BuildingPropertyId", "dbo.BuildingProperty");
            DropForeignKey("dbo.OrganisationToProperty", "OrganisationId", "dbo.Organisation");
            DropIndex("dbo.OrganisationToProperty", new[] { "BuildingPropertyId" });
            DropIndex("dbo.OrganisationToProperty", new[] { "OrganisationId" });
            DropTable("dbo.OrganisationToProperty");
            DropTable("dbo.Organisation");
            DropTable("dbo.BuildingProperty");
        }
    }
}
