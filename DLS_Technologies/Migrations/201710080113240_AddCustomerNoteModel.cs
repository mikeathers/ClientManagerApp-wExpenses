namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerNoteModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerNotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Note = c.String(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerNotes", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerNotes", new[] { "CustomerId" });
            DropTable("dbo.CustomerNotes");
        }
    }
}
