namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seededMultipleUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Caps], [IsBanned]) VALUES (N'e5f78306-5dbd-4ab6-9bca-ec520926b535', N'bigwinner@cash.com', 0, N'AFx17NsaeSIYX9gxTfT+tU92FZvTjkUjce0XYI+Cedzn//n6ahvgygIHTrtwkQ9uVQ==', N'2390e8dc-e39a-4be6-b416-3dc2c5512a8e', NULL, 0, 0, NULL, 1, 0, N'bigwinner@cash.com', 0, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Caps], [IsBanned]) VALUES (N'fdef6194-0fd1-4e6b-a7b9-a4c4f546a1bd', N'bigloser@cash.com', 0, N'AHj5YLdXYw5aEiXIHEUa5OLuBw7PVwPUyY/8EcFQWqmvjDUBpp1Py0HtoWQPureeMw==', N'7d9ccdbe-f78e-4eb2-b5a8-cab6b30f620a', NULL, 0, 0, NULL, 1, 0, N'bigloser@cash.com', 0, 0)

                ");
        }
        
        public override void Down()
        {
        }
    }
}
