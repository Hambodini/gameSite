namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAdminAccount : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Caps], [IsBanned]) VALUES (N'd7ec3ef3-87ea-4027-8152-f78a99e90759', N'trimeyers1@gmail.com', 0, N'ABVjCOCiGNivlVhMo87KvqscTRRWrRCn627fIMBNuooj51DrRAFYkwzswzdb+7uyCw==', N'ba1908a3-8e7f-44eb-bcf7-c591f3635397', NULL, 0, 0, NULL, 1, 0, N'trimeyers1@gmail.com', 0, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
