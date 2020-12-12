using ManageCondo_FP.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ManageCondo_FP.Models
{
    public class ResidentViewModel
    {
        public int ResidentID { get; set; }

        [Required]
        public ResidentType ResidentType { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime MoveInDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(1000)]
        public string EmergencyNotes { get; set; }

        [StringLength(1000)]
        public string EmergencyContact { get; set; }

        public bool HavePets { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int UnitID { get; set; }

        public UserViewModel User { get; set; }
        public SelectList Users { get; set; }
        public UnitViewModel Unit { get; set; }

        public SelectList Units { get; set; }


    }
}