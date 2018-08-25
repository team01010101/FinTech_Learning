using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Models.Hackathon
{
    public class Notification
    {
        [Key]
        public Guid NotificationGuid { get; set; }
        [Required]
        public string Message { get; set; }

        [Required]
        public User UserId { get; set; }
    }
}