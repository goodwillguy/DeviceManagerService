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
                "dbo.Parcels",
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
                        CreateUserId = c.Guid(nullable: false),
                        UpdateUserId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ParcelId);
            
            CreateTable(
                "dbo.ParcelTransactions",
                c => new
                    {
                        ParcelTransactionId = c.Guid(nullable: false),
                        LockerId = c.Guid(nullable: false),
                        ParcelId = c.Guid(nullable: false),
                        TransactionState = c.Int(nullable: false),
                        DropOffAgentId = c.Guid(nullable: false),
                        AgentType = c.Int(nullable: false),
                        DropoffTime = c.DateTime(nullable: false),
                        CreateUserId = c.Guid(nullable: false),
                        UpdateUserId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ParcelTransactionId)//foreging key parent table dbo.Parcels dependent table dbo.ParcelTransactions
                
                .ForeignKey("dbo.Parcels", t => t.ParcelId, cascadeDelete: true)
                .Index(t => t.ParcelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ParcelTransactions", "ParcelId", "dbo.Parcels");
            DropIndex("dbo.ParcelTransactions", new[] { "ParcelId" });
            DropTable("dbo.ParcelTransactions");
            DropTable("dbo.Parcels");
        }
    }
}
