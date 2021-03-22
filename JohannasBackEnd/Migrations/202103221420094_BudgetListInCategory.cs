namespace JohannasBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BudgetListInCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "Budget_Id", "dbo.Budgets");
            DropIndex("dbo.Categories", new[] { "Budget_Id" });
            CreateTable(
                "dbo.CategoryBudgets",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Budget_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Budget_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Budgets", t => t.Budget_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Budget_Id);
            
            DropColumn("dbo.Categories", "Budget_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Budget_Id", c => c.Int());
            DropForeignKey("dbo.CategoryBudgets", "Budget_Id", "dbo.Budgets");
            DropForeignKey("dbo.CategoryBudgets", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryBudgets", new[] { "Budget_Id" });
            DropIndex("dbo.CategoryBudgets", new[] { "Category_Id" });
            DropTable("dbo.CategoryBudgets");
            CreateIndex("dbo.Categories", "Budget_Id");
            AddForeignKey("dbo.Categories", "Budget_Id", "dbo.Budgets", "Id");
        }
    }
}
