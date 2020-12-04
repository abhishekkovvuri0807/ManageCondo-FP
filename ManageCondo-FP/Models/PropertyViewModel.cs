using ManageCondo_FP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageCondo_FP.Models
{
    public class PropertyViewModel
    {
        public int PropertyID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Address { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public PropertyStatus Status { get; set; }

        [Required]
        [Phone]
        [MaxLength(10)]
        public string Phone { get; set; }

    }
}