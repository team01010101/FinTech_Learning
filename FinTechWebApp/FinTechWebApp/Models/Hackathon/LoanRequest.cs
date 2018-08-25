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
        public short Status { get; set; }

        [Required]
        public User UserId { get; set; }
    }
}