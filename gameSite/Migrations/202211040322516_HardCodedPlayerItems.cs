namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HardCodedPlayerItems : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[PlayerItems] ON
INSERT INTO [dbo].[PlayerItems] ([Inventoryid], [Userid], [Itemid], [Quantity], [Useremail]) VALUES (1, N'e5f78306-5dbd-4ab6-9bca-ec520926b535', 3, 2, N'bigwinner@cash.com')
INSERT INTO [dbo].[PlayerItems] ([Inventoryid], [Userid], [Itemid], [Quantity], [Useremail]) VALUES (2, N'e5f78306-5dbd-4ab6-9bca-ec520926b535', 4, 3, N'bigwinner@cash.com')
INSERT INTO [dbo].[PlayerItems] ([Inventoryid], [Userid], [Itemid], [Quantity], [Useremail]) VALUES (3, N'fdef6194-0fd1-4e6b-a7b9-a4c4f546a1bd', 1, 1, N'bigloser@cash.com')
SET IDENTITY_INSERT [dbo].[PlayerItems] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
