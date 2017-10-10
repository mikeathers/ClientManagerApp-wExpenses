namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInitialNoteInCustomerToNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Note", c => c.String());
            DropColumn("dbo.Customers", "InitialNote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "InitialNote", c => c.String());
            DropColumn("dbo.Customers", "Note");
        }
    }
}
