namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cf5cbe1f-f160-4c2e-a17b-b78a76967ab9', N'guest@vidly.com', 0, N'AILKpSikv0EjwUBMouZT3a3fUDkc/fu5Q/PkogOKU4bjclfP7P3QtaJZ6RlhVfnP3w==', N'47e9845a-7008-4b9c-8ef0-7115414b98af', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fe8558a1-3f8b-4453-ab26-6d559cba7d07', N'admin@vidly.com', 0, N'AKnFezAVC7EpdxhjkjbI6kJ3O5AEm3MRLTP0KDsoHsmkJy9UjclkcSKm+wrmD2DVhQ==', N'1f6dfdb8-cc73-487b-8d46-c4452a3771b3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e7d4c5dc-2dcd-406a-9994-b619416ae32e', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fe8558a1-3f8b-4453-ab26-6d559cba7d07', N'e7d4c5dc-2dcd-406a-9994-b619416ae32e')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
