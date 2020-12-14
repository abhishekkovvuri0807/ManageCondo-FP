using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.DomainModels
{
    [Table("Parcels")]
    public class Parcel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Courier { get; set; }

        [Required]
        public string Status { get; set; }

        public bool IsIncoming { get; set; }

        [Required]
        public int NumberOfPeices { get; set; }

        //public DateTime DateRecieved { get; set; }

        //public DateTime DateReleased { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int ResidentID { get; set; }

        public Resident Resident { get; set; }

    }
}