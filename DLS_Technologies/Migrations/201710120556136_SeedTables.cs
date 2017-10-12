namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTables : DbMigration
    {
        public override void Up()
        {
            /// Inital Seed of Database for the following tables.

            // Seed AspNetRoles Table
            Sql("INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'c4445fc1-6d93-4191-884b-e71c6ae9357e', N'Admin')");

            // Seed AspNetUsers Table
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [FullName] ) VALUES (N'1d9bc60d-a7cf-42fd-a3e0-c5484d226a75', N'admin@dlstech.co.uk', 0, N'ABZ5QTDPa2Ej6QldIaxTsryYV9aP5uT86hxdwGmZbdeRqP4xv0m3YkhMGP/+zTZJog==', N'd951574a-247f-464b-887b-c32c42349bc2', NULL, 0, 0, NULL, 1, 0, N'admin@dlstech.co.uk', 'DLS', 'Admin', 'DLS Admin')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FirstName], [LastName], [FullName]) VALUES (N'aae95ea7-ee37-4583-aca2-1ba3a11b99dc', N'guest@dlstech.co.uk', 0, N'AOclF4Sys3FUybwEBz+LdnnokmQ5b+NvBQN1wc8nBQfn71DY5VRW0xj9+YzQAH7iSQ==', N'ca28b8c0-f590-4f76-8ffe-b8797add6b15', NULL, 0, 0, NULL, 1, 0, N'guest@dlstech.co.uk', 'DLS', 'Guest', 'DLS Guest')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d9bc60d-a7cf-42fd-a3e0-c5484d226a75', N'c4445fc1-6d93-4191-884b-e71c6ae9357e')
            ");


            // Seed AccountTypes Table
            Sql("INSERT INTO AccountTypes (Name, MonthlySiteVisit) VALUES ('Gold', 'True')");
            Sql("INSERT INTO AccountTypes (Name, MonthlySiteVisit) VALUES ('Silver', 'False')");
            Sql("INSERT INTO AccountTypes (Name, MonthlySiteVisit) VALUES ('Bronze', 'False')");

            // Seed ExpenseTypes Table.
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Mileage')");
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Parking')");
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Food/Drink')");
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Hotel/Entertainment')");
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Other')");
        }
        
        public override void Down()
        {
        }
    }
}
