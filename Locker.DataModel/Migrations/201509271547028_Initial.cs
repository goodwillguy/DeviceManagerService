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
                "dbo.Device",
                c => new
                    {
                        DeviceId = c.Guid(nullable: false),
                        LockerBankId = c.Guid(nullable: false),
                        SerialNumber = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        DeviceType = c.Int(nullable: false),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.DeviceId)//foreging key parent table dbo.LockerBank dependent table dbo.Device
                
                .ForeignKey("dbo.LockerBank", t => t.LockerBankId, cascadeDelete: true)
                .Index(t => t.LockerBankId);
            
            CreateTable(
                "dbo.LockerBank",
                c => new
                    {
                        LockerBankId = c.Guid(nullable: false),
                        LockerBankCode = c.String(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        IpAddress = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        BuildingPropertyId = c.Guid(nullable: false),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.LockerBankId)//foreging key parent table dbo.BuildingProperty dependent table dbo.LockerBank
                
                .ForeignKey("dbo.BuildingProperty", t => t.BuildingPropertyId, cascadeDelete: true)
                .Index(t => t.BuildingPropertyId);
            
            CreateTable(
                "dbo.Locker",
                c => new
                    {
                        LockerId = c.Guid(nullable: false),
                        LockerBankId = c.Guid(nullable: false),
                        State = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        LockerOfflineReasonId = c.Guid(),
                        LockerNumber = c.String(),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.LockerId)//foreging key parent table dbo.LockerBank dependent table dbo.Locker
                
                .ForeignKey("dbo.LockerBank", t => t.LockerBankId, cascadeDelete: true)
                .Index(t => t.LockerBankId);
            
            CreateTable(
                "dbo.LockerToDevice",
                c => new
                    {
                        LockerToDeviceId = c.Guid(nullable: false, identity: true),
                        LockerId = c.Guid(nullable: false),
                        DeviceId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LockerToDeviceId)//foreging key parent table dbo.Device dependent table dbo.LockerToDevice
                
                .ForeignKey("dbo.Device", t => t.DeviceId, cascadeDelete: true)//foreging key parent table dbo.Locker dependent table dbo.LockerToDevice
                
                .ForeignKey("dbo.Locker", t => t.LockerId, cascadeDelete: false)
                .Index(t => t.LockerId)
                .Index(t => t.DeviceId);
            
            CreateTable(
                "dbo.LockerOfflineReason",
                c => new
                    {
                        LockerOfflineReasonId = c.Guid(nullable: false),
                        Code = c.String(),
                        Description = c.String(),
                        CreateUserId = c.Guid(),
                        UpdateUserId = c.Guid(),
                        CreationTime = c.DateTime(),
                        LastUpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.LockerOfflineReasonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcel", "LockerBankId", "dbo.LockerBank");
            DropForeignKey("dbo.Locker", "LockerBankId", "dbo.LockerBank");
            DropForeignKey("dbo.LockerToDevice", "LockerId", "dbo.Locker");
            DropForeignKey("dbo.LockerToDevice", "DeviceId", "dbo.Device");
            DropForeignKey("dbo.Device", "LockerBankId", "dbo.LockerBank");
            DropIndex("dbo.LockerToDevice", new[] { "DeviceId" });
            DropIndex("dbo.LockerToDevice", new[] { "LockerId" });
            DropIndex("dbo.Locker", new[] { "LockerBankId" });
            DropIndex("dbo.LockerBank", new[] { "BuildingPropertyId" });
            DropIndex("dbo.Device", new[] { "LockerBankId" });
            DropTable("dbo.LockerOfflineReason");
            DropTable("dbo.LockerToDevice");
            DropTable("dbo.Locker");
            DropTable("dbo.LockerBank");
            DropTable("dbo.Device");
        }
    }
}
