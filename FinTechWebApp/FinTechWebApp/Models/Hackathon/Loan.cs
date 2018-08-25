using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Models.Hackathon
{
    public class Loan
    {
        [Key]
        public Guid LoanGuid { get; set; }

        [Required]
        public short Status { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}