namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerToCustomerNotes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CustomerNotes", "CustomerId");
            AddForeignKey("dbo.CustomerNotes", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerNotes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerNotes", new[] { "CustomerId" });
        }
    }
}
