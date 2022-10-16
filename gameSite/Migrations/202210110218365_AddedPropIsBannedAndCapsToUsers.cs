namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropIsBannedAndCapsToUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Caps", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsBanned", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "IsBanned");
            DropColumn("dbo.AspNetUsers", "Caps");
        }
    }
}
