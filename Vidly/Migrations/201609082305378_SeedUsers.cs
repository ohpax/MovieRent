namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3eb4dc05-3726-472d-b36b-a62ecfe77e82', N'CanManageMovies')
");
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2ac968bd-d620-4952-b35e-f6ce3f7170a6', N'admin@vidly.com', 0, N'AAaOoynW3NAxoQy9nXdCdL1cgzETXzdmSHwvt/15fcOb5LQa6o9CvaMIO/PfxSbqCA==', N'a323ae06-cff8-4db1-a56a-01341eb1826d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'adc3e018-3361-410a-9e78-ccfc982f39f8', N'guest@vidly.com', 0, N'AAb2JBGXEOgxTAhu9UXXietqsLYO126dfXiKNla0MKO6G8cjQjQl/GRHEx1ixjvQpg==', N'727a33fb-1720-432d-aa69-427ed6a31eb6', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
");
            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2ac968bd-d620-4952-b35e-f6ce3f7170a6', N'3eb4dc05-3726-472d-b36b-a62ecfe77e82')
");
        }
        
        public override void Down()
        {
        }
    }
}
