namespace FinTechWebApp.Migrations.Hackathon
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLoanUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loans", "User_UserId", "dbo.Users");
            DropIndex("dbo.Loans", new[] { "User_UserId" });
            AlterColumn("dbo.Loans", "User_UserId", c => c.String(maxLength: 10));
            CreateIndex("dbo.Loans", "User_UserId");
            AddForeignKey("dbo.Loans", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "User_UserId", "dbo.Users");
            DropIndex("dbo.Loans", new[] { "User_UserId" });
            AlterColumn("dbo.Loans", "User_UserId", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.Loans", "User_UserId");
            AddForeignKey("dbo.Loans", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
