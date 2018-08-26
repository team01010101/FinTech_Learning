using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Models.Hackathon
{
    public class LoanType
    {
        [Key]
        public Guid LoanTypeGuid { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int MaxPaymentPeriod { get; set; }

        public double InterestRate { get; set; }
    }
}