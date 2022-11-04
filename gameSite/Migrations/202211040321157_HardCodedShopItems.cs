namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HardCodedShopItems : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[ShopItems] ON
INSERT INTO [dbo].[ShopItems] ([Itemid], [Price], [Name]) VALUES (1, 50, N'Big Horn Horns')
INSERT INTO [dbo].[ShopItems] ([Itemid], [Price], [Name]) VALUES (2, 100, N'Radiated Lucky Rabbits Foot')
INSERT INTO [dbo].[ShopItems] ([Itemid], [Price], [Name]) VALUES (3, 200, N'Lucky Lucy Figure')
INSERT INTO [dbo].[ShopItems] ([Itemid], [Price], [Name]) VALUES (4, 200, N'Vintage Rescource War Coupons')
SET IDENTITY_INSERT [dbo].[ShopItems] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
