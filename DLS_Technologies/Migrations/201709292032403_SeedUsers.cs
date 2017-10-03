namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1d9bc60d-a7cf-42fd-a3e0-c5484d226a75', N'admin@dlstech.co.uk', 0, N'ABZ5QTDPa2Ej6QldIaxTsryYV9aP5uT86hxdwGmZbdeRqP4xv0m3YkhMGP/+zTZJog==', N'd951574a-247f-464b-887b-c32c42349bc2', NULL, 0, 0, NULL, 1, 0, N'admin@dlstech.co.uk')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'aae95ea7-ee37-4583-aca2-1ba3a11b99dc', N'guest@dlstech.co.uk', 0, N'AOclF4Sys3FUybwEBz+LdnnokmQ5b+NvBQN1wc8nBQfn71DY5VRW0xj9+YzQAH7iSQ==', N'ca28b8c0-f590-4f76-8ffe-b8797add6b15', NULL, 0, 0, NULL, 1, 0, N'guest@dlstech.co.uk')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d9bc60d-a7cf-42fd-a3e0-c5484d226a75', N'c4445fc1-6d93-4191-884b-e71c6ae9357e')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
