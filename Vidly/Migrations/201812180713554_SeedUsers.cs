namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'26790ca5-b659-4676-9929-11d7512156e7', N'admin@vidly.com', 0, N'ADMGHu92f+7B1hApV19gx9QOwEFO5YkQBOJlbltTfmRIxoxt5HUp/BxrRp+q6IvMSQ==', N'4cceb15e-88e8-4ad6-8e97-99d19e94bdea', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c84362f1-1170-466b-bfbf-76899e5d332c', N'guest@gmail.com', 0, N'AC4AsPtXV4elhQ44+Dhi3B90ynLyE6Trw6CDJMJ+bD19Xruzwq+ni+1kV7EdvvCDog==', N'2753c0f6-e8af-4de0-8ee2-14ecc056ab19', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'230f9f92-491a-4d15-be95-db91e1055b2a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'26790ca5-b659-4676-9929-11d7512156e7', N'230f9f92-491a-4d15-be95-db91e1055b2a')
");
        }
        
        public override void Down()
        {
        }
    }
}
