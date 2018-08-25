using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Models.Hackathon
{
    public class Payment
    {
        [Key]
        public Guid PaymentGuid { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public Loan Loan { get; set; }
    }
}