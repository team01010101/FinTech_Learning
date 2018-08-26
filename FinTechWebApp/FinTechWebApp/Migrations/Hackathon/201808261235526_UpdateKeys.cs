namespace FinTechWebApp.Migrations.Hackathon
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateKeys : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Loans", name: "User_UserId", newName: "UserId");
            RenameIndex(table: "dbo.Loans", name: "IX_User_UserId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Loans", name: "IX_UserId", newName: "IX_User_UserId");
            RenameColumn(table: "dbo.Loans", name: "UserId", newName: "User_UserId");
        }
    }
}
