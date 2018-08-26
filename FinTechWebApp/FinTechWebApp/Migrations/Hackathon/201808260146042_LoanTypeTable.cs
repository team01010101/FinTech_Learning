namespace FinTechWebApp.Migrations.Hackathon
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanTypeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Loans", "User_UserId", "dbo.Users");
            DropIndex("dbo.Loans", new[] { "User_UserId" });
            RenameColumn(table: "dbo.Notifications", name: "UserId_UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.LoanRequests", name: "UserId_UserId", newName: "User_UserId");
            RenameIndex(table: "dbo.LoanRequests", name: "IX_UserId_UserId", newName: "IX_User_UserId");
            RenameIndex(table: "dbo.Notifications", name: "IX_UserId_UserId", newName: "IX_User_UserId");
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        LoanTypeGuid = c.Guid(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        MaxPaymentPeriod = c.Int(nullable: false),
                        InterestRate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LoanTypeGuid);
            
            AddColumn("dbo.LoanRequests", "EmploymentType", c => c.Short(nullable: false));
            AddColumn("dbo.LoanRequests", "RequestedAmount", c => c.Double(nullable: false));
            AddColumn("dbo.LoanRequests", "MonthlyIncome", c => c.Double(nullable: false));
            AddColumn("dbo.LoanRequests", "PaymentPeriod", c => c.DateTime(nullable: false));
            AddColumn("dbo.LoanRequests", "LoanType_LoanTypeGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "CreditPoints", c => c.Int(nullable: false));
            AddColumn("dbo.Loans", "LendAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Loans", "DisbursementAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Loans", "ExpirationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Loans", "OutstandingBalance", c => c.Double(nullable: false));
            AddColumn("dbo.Loans", "LoanType_LoanTypeGuid", c => c.Guid(nullable: false));
            AddColumn("dbo.Payments", "PaidAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Payments", "InvoicedAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Payments", "InvoiceNumber", c => c.String());
            AddColumn("dbo.Payments", "Status", c => c.Short(nullable: false));
            AddColumn("dbo.Payments", "InvoicedDueDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "PaymentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Loans", "User_UserId", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.LoanRequests", "LoanType_LoanTypeGuid");
            CreateIndex("dbo.Loans", "LoanType_LoanTypeGuid");
            CreateIndex("dbo.Loans", "User_UserId");
            AddForeignKey("dbo.LoanRequests", "LoanType_LoanTypeGuid", "dbo.LoanTypes", "LoanTypeGuid", cascadeDelete: true);
            AddForeignKey("dbo.Loans", "LoanType_LoanTypeGuid", "dbo.LoanTypes", "LoanTypeGuid", cascadeDelete: true);
            AddForeignKey("dbo.Loans", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.Payments", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "Amount", c => c.Double(nullable: false));
            DropForeignKey("dbo.Loans", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Loans", "LoanType_LoanTypeGuid", "dbo.LoanTypes");
            DropForeignKey("dbo.LoanRequests", "LoanType_LoanTypeGuid", "dbo.LoanTypes");
            DropIndex("dbo.Loans", new[] { "User_UserId" });
            DropIndex("dbo.Loans", new[] { "LoanType_LoanTypeGuid" });
            DropIndex("dbo.LoanRequests", new[] { "LoanType_LoanTypeGuid" });
            AlterColumn("dbo.Loans", "User_UserId", c => c.String(maxLength: 10));
            DropColumn("dbo.Payments", "PaymentDate");
            DropColumn("dbo.Payments", "InvoicedDueDate");
            DropColumn("dbo.Payments", "Status");
            DropColumn("dbo.Payments", "InvoiceNumber");
            DropColumn("dbo.Payments", "InvoicedAmount");
            DropColumn("dbo.Payments", "PaidAmount");
            DropColumn("dbo.Loans", "LoanType_LoanTypeGuid");
            DropColumn("dbo.Loans", "OutstandingBalance");
            DropColumn("dbo.Loans", "ExpirationDate");
            DropColumn("dbo.Loans", "DisbursementAmount");
            DropColumn("dbo.Loans", "LendAmount");
            DropColumn("dbo.Users", "CreditPoints");
            DropColumn("dbo.LoanRequests", "LoanType_LoanTypeGuid");
            DropColumn("dbo.LoanRequests", "PaymentPeriod");
            DropColumn("dbo.LoanRequests", "MonthlyIncome");
            DropColumn("dbo.LoanRequests", "RequestedAmount");
            DropColumn("dbo.LoanRequests", "EmploymentType");
            DropTable("dbo.LoanTypes");
            RenameIndex(table: "dbo.Notifications", name: "IX_User_UserId", newName: "IX_UserId_UserId");
            RenameIndex(table: "dbo.LoanRequests", name: "IX_User_UserId", newName: "IX_UserId_UserId");
            RenameColumn(table: "dbo.LoanRequests", name: "User_UserId", newName: "UserId_UserId");
            RenameColumn(table: "dbo.Notifications", name: "User_UserId", newName: "UserId_UserId");
            CreateIndex("dbo.Loans", "User_UserId");
            AddForeignKey("dbo.Loans", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
