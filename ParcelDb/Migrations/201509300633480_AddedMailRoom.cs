namespace Tz.Parcel.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMailRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parcel", "MailRoomId", c => c.Guid());
            CreateIndex("dbo.Parcel", "LockerId");
            AddForeignKey("dbo.Parcel", "LockerId", "dbo.Locker", "LockerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcel", "LockerId", "dbo.Locker");
            DropIndex("dbo.Parcel", new[] { "LockerId" });
            DropColumn("dbo.Parcel", "MailRoomId");
        }
    }
}
