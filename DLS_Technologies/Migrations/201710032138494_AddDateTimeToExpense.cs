namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeToExpense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "DateTime");
        }
    }
}
