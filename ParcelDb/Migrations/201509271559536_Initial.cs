namespace Tz.Parcel.DataModel.Migrations
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
                "dbo.Parcel",
                c => new
                    {
                        ParcelId = c.Guid(nullable: false),
                        OrganizationId = c.Guid(nullable: false),
                        ConsignmentNumber = c.String(),
                        SenderId = c.Guid(),
                        RecipientId = c.Guid(nullable: false),
                        Size = c.Int(nullable: false),
                        IsExpired = c.Boolean(nullable: false),
                        ExpiryTime = c.DateTime(nullable: false),
                        LockerBankId = c.Guid(nullable: false),
                        LockerId = c.Guid(),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ParcelId);
            
            CreateTable(
                "dbo.ParcelTransaction",
                c => new
                    {
                        ParcelTransactionId = c.Guid(nullable: false),
                        LockerId = c.Guid(nullable: false),
                        ParcelId = c.Guid(nullable: false),
                        TransactionState = c.Int(nullable: false),
                        DropOffAgentId = c.Guid(nullable: false),
                        AgentType = c.Int(nullable: false),
                        DropoffTime = c.DateTime(nullable: false),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.ParcelTransactionId)//foreging key parent table dbo.Agent dependent table dbo.ParcelTransaction
                
                .ForeignKey("dbo.Agent", t => t.DropOffAgentId, cascadeDelete: true)//foreging key parent table dbo.Parcel dependent table dbo.ParcelTransaction
                
                .ForeignKey("dbo.Parcel", t => t.ParcelId, cascadeDelete: true)
                .Index(t => t.ParcelId)
                .Index(t => t.DropOffAgentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParcelTransaction", "ParcelId", "dbo.Parcel");
            DropIndex("dbo.ParcelTransaction", new[] { "DropOffAgentId" });
            DropIndex("dbo.ParcelTransaction", new[] { "ParcelId" });
            DropTable("dbo.ParcelTransaction");
            DropTable("dbo.Parcel");
        }
    }
}
