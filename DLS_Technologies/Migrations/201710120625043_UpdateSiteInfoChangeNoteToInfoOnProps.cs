namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSiteInfoChangeNoteToInfoOnProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteInfoes", "NetworkInfo", c => c.String());
            AddColumn("dbo.SiteInfoes", "WifiInfo", c => c.String());
            AddColumn("dbo.SiteInfoes", "DomainInfo", c => c.String());
            DropColumn("dbo.SiteInfoes", "NetworkNote");
            DropColumn("dbo.SiteInfoes", "WifiNote");
            DropColumn("dbo.SiteInfoes", "DomainNote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SiteInfoes", "DomainNote", c => c.String());
            AddColumn("dbo.SiteInfoes", "WifiNote", c => c.String());
            AddColumn("dbo.SiteInfoes", "NetworkNote", c => c.String());
            DropColumn("dbo.SiteInfoes", "DomainInfo");
            DropColumn("dbo.SiteInfoes", "WifiInfo");
            DropColumn("dbo.SiteInfoes", "NetworkInfo");
        }
    }
}
