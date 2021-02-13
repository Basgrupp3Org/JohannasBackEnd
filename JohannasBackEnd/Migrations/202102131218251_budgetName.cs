namespace JohannasBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class budgetName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Budgets", "BudgetName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Budgets", "BudgetName");
        }
    }
}
