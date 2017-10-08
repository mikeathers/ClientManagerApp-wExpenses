namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomerFromCustomerNotes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerNotes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerNotes", new[] { "CustomerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.CustomerNotes", "CustomerId");
            AddForeignKey("dbo.CustomerNotes", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
