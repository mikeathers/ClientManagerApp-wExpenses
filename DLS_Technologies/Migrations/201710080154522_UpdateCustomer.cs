namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "InitialNote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "InitialNote");
        }
    }
}
