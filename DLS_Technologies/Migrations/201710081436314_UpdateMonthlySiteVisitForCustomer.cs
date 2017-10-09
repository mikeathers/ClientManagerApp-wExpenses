namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMonthlySiteVisitForCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MonthlySiteVisitDate", c => c.DateTime());
            DropColumn("dbo.Customers", "MonthlySiteVisit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MonthlySiteVisit", c => c.DateTime());
            DropColumn("dbo.Customers", "MonthlySiteVisitDate");
        }
    }
}
