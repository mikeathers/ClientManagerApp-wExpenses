namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactOnSiteToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ContactOnSite", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ContactOnSite");
        }
    }
}
