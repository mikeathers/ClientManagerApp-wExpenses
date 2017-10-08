namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAccountTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AccountTypes (Name, MonthlySiteVisit) VALUES ('Gold', 'True')");
            Sql("INSERT INTO AccountTypes (Name, MonthlySiteVisit) VALUES ('Silver', 'False')");
            Sql("INSERT INTO AccountTypes (Name, MonthlySiteVisit) VALUES ('Bronze', 'False')");
        }
        
        public override void Down()
        {
        }
    }
}
