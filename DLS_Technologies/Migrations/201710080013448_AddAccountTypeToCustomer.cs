namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTypeToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AccountTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "AccountTypeId");
            AddForeignKey("dbo.Customers", "AccountTypeId", "dbo.AccountTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AccountTypeId", "dbo.AccountTypes");
            DropIndex("dbo.Customers", new[] { "AccountTypeId" });
            DropColumn("dbo.Customers", "AccountTypeId");
        }
    }
}
