using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DexaApps.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string FullName { get; set; }
    }
}
