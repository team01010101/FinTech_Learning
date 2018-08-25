namespace FinTechWebApp.Migrations.Hackathon
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoanRequests",
                c => new
                    {
                        LoanRequestGuid = c.Guid(nullable: false),
                        Status = c.Short(nullable: false),
                        UserId_UserId = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.LoanRequestGuid)
                .ForeignKey("dbo.Users", t => t.UserId_UserId, cascadeDelete: true)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        LoanGuid = c.Guid(nullable: false),
                        Status = c.Short(nullable: false),
                        User_UserId = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.LoanGuid)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentGuid = c.Guid(nullable: false),
                        Amount = c.Double(nullable: false),
                        Loan_LoanGuid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentGuid)
                .ForeignKey("dbo.Loans", t => t.Loan_LoanGuid, cascadeDelete: true)
                .Index(t => t.Loan_LoanGuid);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationGuid = c.Guid(nullable: false),
                        Message = c.String(nullable: false),
                        UserId_UserId = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.NotificationGuid)
                .ForeignKey("dbo.Users", t => t.UserId_UserId, cascadeDelete: true)
                .Index(t => t.UserId_UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleGuid = c.Guid(nullable: false),
                        User_UserId = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.UserRoleGuid)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanRequests", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Notifications", "UserId_UserId", "dbo.Users");
            DropForeignKey("dbo.Loans", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Payments", "Loan_LoanGuid", "dbo.Loans");
            DropIndex("dbo.UserRoles", new[] { "User_UserId" });
            DropIndex("dbo.Notifications", new[] { "UserId_UserId" });
            DropIndex("dbo.Payments", new[] { "Loan_LoanGuid" });
            DropIndex("dbo.Loans", new[] { "User_UserId" });
            DropIndex("dbo.LoanRequests", new[] { "UserId_UserId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.Payments");
            DropTable("dbo.Loans");
            DropTable("dbo.Users");
            DropTable("dbo.LoanRequests");
        }
    }
}
