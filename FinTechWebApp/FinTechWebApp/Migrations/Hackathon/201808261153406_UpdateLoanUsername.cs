namespace FinTechWebApp.Migrations.Hackathon
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLoanUsername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loans", "Username");
        }
    }
}
