namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMonthlySiteVisitToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MonthlySiteVisit", c => c.DateTime());
            AddColumn("dbo.Customers", "MonthlySiteVisitDue", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "MonthlySiteVisitDue");
            DropColumn("dbo.Customers", "MonthlySiteVisit");
        }
    }
}
