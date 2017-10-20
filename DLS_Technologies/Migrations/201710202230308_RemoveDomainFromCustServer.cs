namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDomainFromCustServer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerServers", "Domain");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerServers", "Domain", c => c.String());
        }
    }
}
