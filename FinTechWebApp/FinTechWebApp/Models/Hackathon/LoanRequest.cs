using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Models.Hackathon
{
    public class LoanRequest
    {
        [Key]
        public Guid LoanRequestGuid { get; set; }

        [Required]
        public LoanType LoanType { get; set; }

        [Required]
        public short Status { get; set; }

        public short EmploymentType { get; set; }

        public double RequestedAmount { get; set; }

        public double MonthlyIncome { get; set; }

        public DateTime PaymentPeriod { get; set; }

        [Required]
        public User User { get; set; }
    }
}