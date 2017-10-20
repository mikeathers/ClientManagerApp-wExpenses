namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDomainToCustServers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerServers", "Domain", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerServers", "Domain");
        }
    }
}
