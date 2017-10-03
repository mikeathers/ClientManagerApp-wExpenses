namespace DLS_Technologies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpenseTypesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Mileage')");
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Parking')");
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Food/Drink')");
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Hotel/Entertainment')");
            Sql("INSERT INTO ExpenseTypes (Name) VALUES ('Other')");
        }
        
        public override void Down()
        {
        }
    }
}
