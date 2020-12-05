using ManageCondo_FP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageCondo_FP.Models
{
    public class UserViewModel
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        public UserStatus Status { get; set; }
    }
}