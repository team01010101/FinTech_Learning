using System.Data.Entity;
using FinTechWebApp.Models.Hackathon;

namespace FinTechWebApp.Data
{
    public class HackathonContext : DbContext
    {
        public HackathonContext() : base("DefaultConnection")
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<LoanRequest> LoanRequests { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
    }
}