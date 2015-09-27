namespace Tz.Locker.DataModel.Migrations
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
                "dbo.Devices",
                c => new
                    {
                        DeviceId = c.Guid(nullable: false),
                        LockerBankId = c.Guid(nullable: false),
                        SerialNumber = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        DeviceType = c.Int(nullable: false),
                        CreateUserId = c.Guid(nullable: false),
                        UpdateUserId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId);
            
            CreateTable(
                "dbo.LockerBanks",
                c => new
                    {
                        LockerBankId = c.Guid(nullable: false),
                        LockerBankCode = c.String(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IpAddress = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        BuildingPropertyId = c.Guid(nullable: false),
                        CreateUserId = c.Guid(nullable: false),
                        UpdateUserId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LockerBankId);
            
            CreateTable(
                "dbo.Lockers",
                c => new
                    {
                        LockerId = c.Guid(nullable: false),
                        LockerBankId = c.Guid(nullable: false),
                        State = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        LockerOfflineReasonId = c.Guid(),
                        CreateUserId = c.Guid(nullable: false),
                        UpdateUserId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LockerId)//foreging key parent table dbo.LockerBanks dependent table dbo.Lockers
                
                .ForeignKey("dbo.LockerBanks", t => t.LockerBankId, cascadeDelete: true)
                .Index(t => t.LockerBankId);
            
            CreateTable(
                "dbo.LockerToDevices",
                c => new
                    {
                        LockerToDeviceId = c.Guid(nullable: false, identity: true),
                        LockerId = c.Guid(nullable: false),
                        DeviceId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LockerToDeviceId)//foreging key parent table dbo.Devices dependent table dbo.LockerToDevices
                
                .ForeignKey("dbo.Devices", t => t.DeviceId, cascadeDelete: true)//foreging key parent table dbo.Lockers dependent table dbo.LockerToDevices
                
                .ForeignKey("dbo.Lockers", t => t.LockerId, cascadeDelete: true)
                .Index(t => t.LockerId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.LockerOfflineReasons",
                c => new
                    {
                        LockerOfflineReasonId = c.Guid(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        CreateUserId = c.Guid(nullable: false),
                        UpdateUserId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LockerOfflineReasonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcel", "LockerBankId", "dbo.LockerBanks");
            DropForeignKey("dbo.Lockers", "LockerBankId", "dbo.LockerBanks");
            DropForeignKey("dbo.LockerToDevices", "LockerId", "dbo.Lockers");
            DropForeignKey("dbo.LockerToDevices", "DeviceId", "dbo.Devices");
            DropIndex("dbo.LockerToDevices", new[] { "DeviceId" });
            DropIndex("dbo.LockerToDevices", new[] { "LockerId" });
            DropIndex("dbo.Lockers", new[] { "LockerBankId" });
            DropTable("dbo.LockerOfflineReasons");
            DropTable("dbo.LockerToDevices");
            DropTable("dbo.Lockers");
            DropTable("dbo.LockerBanks");
            DropTable("dbo.Devices");
        }
    }
}
