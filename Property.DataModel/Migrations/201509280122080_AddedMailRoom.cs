namespace Tz.Property.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMailRoom : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailRoom",
                c => new
                    {
                        MailRoomId = c.Guid(nullable: false),
                        MailRoomCode = c.String(),
                    })
                .PrimaryKey(t => t.MailRoomId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MailRoom");
        }
    }
}
