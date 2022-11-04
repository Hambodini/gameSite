namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGames : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Games] ON
INSERT INTO [dbo].[Games] ([GameID], [Name], [UnlockCost]) VALUES (1, N'Coin Flip', 200)
INSERT INTO [dbo].[Games] ([GameID], [Name], [UnlockCost]) VALUES (2, N'Rock, Paper, Scissors', 300)
INSERT INTO [dbo].[Games] ([GameID], [Name], [UnlockCost]) VALUES (3, N'High-Low', 500)
INSERT INTO [dbo].[Games] ([GameID], [Name], [UnlockCost]) VALUES (4, N'Wheel Of Fortune', 600)
INSERT INTO [dbo].[Games] ([GameID], [Name], [UnlockCost]) VALUES (5, N'Slots', 700)
INSERT INTO [dbo].[Games] ([GameID], [Name], [UnlockCost]) VALUES (6, N'Roulette', 800)
INSERT INTO [dbo].[Games] ([GameID], [Name], [UnlockCost]) VALUES (7, N'Baccarat', 900)
INSERT INTO [dbo].[Games] ([GameID], [Name], [UnlockCost]) VALUES (8, N'BlackJack', 0)
SET IDENTITY_INSERT [dbo].[Games] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
