namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateJoinedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateJoined", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateJoined");
        }
    }
}
