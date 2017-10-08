namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "PostCode", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ContactInfo", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "ContactInfo");
            DropColumn("dbo.Customers", "PostCode");
            DropColumn("dbo.Customers", "Address");
        }
    }
}
