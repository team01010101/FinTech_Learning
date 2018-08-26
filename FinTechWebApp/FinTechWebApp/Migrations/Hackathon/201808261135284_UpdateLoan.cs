namespace FinTechWebApp.Migrations.Hackathon
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLoan : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loans", "LoanType_LoanTypeGuid", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "LoanType_LoanTypeGuid" });
            AddColumn("dbo.Loans", "LoanType", c => c.Short(nullable: false));
            DropColumn("dbo.Loans", "LoanType_LoanTypeGuid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Loans", "LoanType_LoanTypeGuid", c => c.Guid(nullable: false));
            DropColumn("dbo.Loans", "LoanType");
            CreateIndex("dbo.Loans", "LoanType_LoanTypeGuid");
            AddForeignKey("dbo.Loans", "LoanType_LoanTypeGuid", "dbo.LoanTypes", "LoanTypeGuid", cascadeDelete: true);
        }
    }
}
