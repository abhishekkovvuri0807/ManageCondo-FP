using ManageCondo_FP.Common;
using ManageCondo_FP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ManageCondo.DomainModels
{

    public class ParcelViewModel
    {

        public int ParcelID { get; set; }

        [Required]
        public string Courier { get; set; }

        [Required]
        public bool isIncoming { get; set; }

        [Required]
        public int NumberOfPeices { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DateRecieved { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime DateReleased { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public ParcelStatus Staus { get; set; }

        public int ResidentID { get; set; }

        public ResidentViewModel Resident { get; set; }

        public int UserID { get; set; }


        public SelectList Users { get; set; }
    }
}