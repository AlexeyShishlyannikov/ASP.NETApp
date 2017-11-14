namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'94a7cad3-0cba-4ed7-b41d-e5867d64df72', N'admin@vidly.com', 0, N'AJoiE8X8ELsax5dy8wSUTz/FiHGzd7aqujdS7uPol2JGAlhbOzGvJv+6OlEbcElgig==', N'f0060d42-7d0b-4435-a9c6-240d1fc93682', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c01a4444-d771-49c1-b071-a14f25cc5223', N'guest@vidly.com', 0, N'AM4iRWUYj8CrqEHBF5e7mRXBjU6UWxwFnCFdc8qcvUN16hZUIkUb+ahR1djaStVyDQ==', N'0a1991d4-3e1d-41ae-ab85-909fa3fda94e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fb7fdd2b-830b-42c7-85a8-e446eed3be31', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'94a7cad3-0cba-4ed7-b41d-e5867d64df72', N'fb7fdd2b-830b-42c7-85a8-e446eed3be31')


");
        }
        
        public override void Down()
        {
        }
    }
}
