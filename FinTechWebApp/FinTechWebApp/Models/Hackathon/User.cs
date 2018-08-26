using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Models.Hackathon
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string UserId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public int CreditPoints { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Loan> Loans { get; set; }
        public ICollection<LoanRequest> Requests { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}