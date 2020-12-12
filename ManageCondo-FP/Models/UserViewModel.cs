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

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(255, ErrorMessage = "First name cannot exceed 255 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(255, ErrorMessage = "Last name cannot exceed 255 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, ErrorMessage = "Password cannot exceed 255 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)\S{6,20}$", ErrorMessage = "Invalid password format")]
        public string Password { get; set; }

        [Required]
        [StringLength(255)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public UserRole Role { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public UserStatus Status { get; set; }
    }
}