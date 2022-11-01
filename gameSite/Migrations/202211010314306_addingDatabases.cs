namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDatabases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UnlockCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameID);
            
            CreateTable(
                "dbo.PlayerGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gameid = c.Int(nullable: false),
                        Userid = c.Int(nullable: false),
                        Useremail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlayerItems",
                c => new
                    {
                        Inventoryid = c.Int(nullable: false, identity: true),
                        Userid = c.Int(nullable: false),
                        Itemid = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Useremail = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Inventoryid);
            
            CreateTable(
                "dbo.ShopItems",
                c => new
                    {
                        Itemid = c.Int(nullable: false, identity: true),
                        Price = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Itemid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShopItems");
            DropTable("dbo.PlayerItems");
            DropTable("dbo.PlayerGames");
            DropTable("dbo.Games");
        }
    }
}
