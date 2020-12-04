using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageCondo.DomainModels
{
    [Table("Unit")]
    public class Unit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }

        [StringLength(255)]
        public string FobKey { get; set; }

        public bool isRentedOut { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int PropertyID { get; set; }

        public Property Property { get; set; }

    }
}
