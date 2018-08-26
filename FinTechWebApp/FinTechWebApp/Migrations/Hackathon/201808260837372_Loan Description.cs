namespace FinTechWebApp.Migrations.Hackathon
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Loans", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Loans", "Description");
        }
    }
}
