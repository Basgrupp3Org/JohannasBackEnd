namespace JohannasBackEnd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameuniq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 20));
            CreateIndex("dbo.Users", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
