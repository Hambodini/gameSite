namespace gameSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAdminAccountToAdminRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd7ec3ef3-87ea-4027-8152-f78a99e90759', N'1')");
        }
        
        public override void Down()
        {
        }
    }
}
