using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Models.Hackathon
{
    public class Loan
    {
        [Key]
        public Guid LoanGuid { get; set; }

        [Required]
        public short LoanType { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Description { get; set; }

        public double LendAmount { get; set; }

        public double DisbursementAmount { get; set; }

        public DateTime ExpirationDate { get; set; }

        public double OutstandingBalance { get; set; }

        [Required]
        public short Status { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}