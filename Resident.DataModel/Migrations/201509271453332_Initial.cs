namespace Tz.Resident.DataModel.Migrations
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
                "dbo.Residents",
                c => new
                    {
                        ResidentId = c.Guid(nullable: false),
                        SignInPin = c.String(),
                        ResidentCode = c.String(),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        MobileNumber = c.String(),
                        IsResidentDisabled = c.Boolean(nullable: false),
                        BuildingPropertyId = c.Guid(nullable: false),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ResidentId)//foreging key parent table dbo.BuildingProperty dependent table dbo.Residents
                
                .ForeignKey("dbo.BuildingProperty", t => t.BuildingPropertyId, cascadeDelete: true)
                .Index(t => t.BuildingPropertyId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Residents", new[] { "BuildingPropertyId" });
            DropTable("dbo.Residents");
        }
    }
}
