using ManageCondo_FP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageCondo_FP.Models
{
    public class UnitViewModel
    {
        public int UnitID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public int Level { get; set; }

        [StringLength(255)]
        public string FobKey { get; set; }

        public bool IsRentedOut { get; set; }

        [Required]
        public UnitStatus Status { get; set; }

        [Required]
        public int PropertyID { get; set; }

        public PropertyViewModel Property { get; set; }

        public SelectList Properties { get; set; }
    }
}