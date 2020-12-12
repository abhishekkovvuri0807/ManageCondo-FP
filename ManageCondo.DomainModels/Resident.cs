using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.DomainModels
{
    [Table("Resident")]
    public class Resident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string ResidentType { get; set; }

        [Required]
        [StringLength(10)]
        public string Phone { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public DateTime MoveInDate { get; set; }


        public DateTime DateOfBirth { get; set; }

        [StringLength(1000)]
        public string EmergencyNotes { get; set; }

        [StringLength(1000)]
        public string EmergencyContact { get; set; }

        public bool HavePets { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int UnitID { get; set; }

        public User User { get; set; }

        public Unit Unit { get; set; }

    }
}
