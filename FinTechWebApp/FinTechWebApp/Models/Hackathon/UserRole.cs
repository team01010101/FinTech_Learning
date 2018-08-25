using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinTechWebApp.Models.Hackathon
{
    public class UserRole
    {
        [Key]
        public Guid UserRoleGuid { get; set; }
    }
}