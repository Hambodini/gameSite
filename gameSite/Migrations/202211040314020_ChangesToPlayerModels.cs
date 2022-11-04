namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToPlayerModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PlayerGames", "Userid", c => c.String(nullable: false));
            AlterColumn("dbo.PlayerItems", "Userid", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PlayerItems", "Userid", c => c.Int(nullable: false));
            AlterColumn("dbo.PlayerGames", "Userid", c => c.Int(nullable: false));
        }
    }
}
