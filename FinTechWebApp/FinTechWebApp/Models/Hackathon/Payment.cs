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
        public double PaidAmount { get; set; }

        public double InvoicedAmount { get; set; }

        public string InvoiceNumber { get; set; }

        public short Status { get; set; }

        public DateTime InvoicedDueDate { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required]
        public Loan Loan { get; set; }
    }
}