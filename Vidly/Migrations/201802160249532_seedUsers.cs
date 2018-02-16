namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e970fbfe-20be-4343-95c1-992c1e1f7f51', N'guest@vidly.com', 0, N'ADqtmFl119BNcprYE2ffWcefmM48uv57yYZRNfy8cPgzbcQl7lpOAMO2dsuf52UWUw==', N'42c90544-de8d-40ca-bbca-7974433fdf1b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ee0e428a-916e-4fc0-8781-7aefaece9258', N'admin@vidly.com', 0, N'AGPmYPGQKun20sZbLYczkjUH9YgYniDSWKnbT5FxtLxChrzASSt8dsqH91hh77hjZw==', N'5b88ce1a-4859-4844-be20-f24ae196582b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8477065f-78f8-4180-a00c-94cc936f150d', N'CanManageMovie')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ee0e428a-916e-4fc0-8781-7aefaece9258', N'8477065f-78f8-4180-a00c-94cc936f150d') ");
        }

        public override void Down()
        {
        }
    }
}
