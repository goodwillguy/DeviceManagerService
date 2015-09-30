namespace Tz.Locker.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumnToLocker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locker", "Column", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locker", "Column");
        }
    }
}
