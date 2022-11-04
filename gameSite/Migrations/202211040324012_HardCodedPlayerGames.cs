namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HardCodedPlayerGames : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[PlayerGames] ON
INSERT INTO [dbo].[PlayerGames] ([Id], [Gameid], [Userid], [Useremail]) VALUES (2, 1, N'e5f78306-5dbd-4ab6-9bca-ec520926b535', N'bigwinner@cash.com')
INSERT INTO [dbo].[PlayerGames] ([Id], [Gameid], [Userid], [Useremail]) VALUES (5, 2, N'e5f78306-5dbd-4ab6-9bca-ec520926b535', N'bigwinner@cash.com')
INSERT INTO [dbo].[PlayerGames] ([Id], [Gameid], [Userid], [Useremail]) VALUES (6, 5, N'fdef6194-0fd1-4e6b-a7b9-a4c4f546a1bd', N'bigloser@cash.com')
SET IDENTITY_INSERT [dbo].[PlayerGames] OFF

");
        }
        
        public override void Down()
        {
        }
    }
}
