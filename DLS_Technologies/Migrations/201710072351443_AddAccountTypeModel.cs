namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTypeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                        MonthlySiteVisit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AccountTypes");
        }
    }
}
