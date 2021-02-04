namespace JohannasBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        BalanceLabel = c.String(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Budgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BudgetSum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxSpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentSpent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Budget_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Budgets", t => t.Budget_Id)
                .Index(t => t.Budget_Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseName = c.String(),
                        Date = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                        Store_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Store_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balances", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Budgets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Purchases", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Purchases", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.Purchases", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Budget_Id", "dbo.Budgets");
            DropIndex("dbo.Purchases", new[] { "User_Id" });
            DropIndex("dbo.Purchases", new[] { "Store_Id" });
            DropIndex("dbo.Purchases", new[] { "Category_Id" });
            DropIndex("dbo.Categories", new[] { "Budget_Id" });
            DropIndex("dbo.Budgets", new[] { "User_Id" });
            DropIndex("dbo.Balances", new[] { "User_Id" });
            DropTable("dbo.Stores");
            DropTable("dbo.Purchases");
            DropTable("dbo.Categories");
            DropTable("dbo.Budgets");
            DropTable("dbo.Users");
            DropTable("dbo.Balances");
        }
    }
}
