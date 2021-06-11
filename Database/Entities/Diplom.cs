using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    [Table("Diploms")]
    public class Diplom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AspirantId { get; set; }

        [ForeignKey("AspirantId")]
        public Aspirant Aspirant { get; set; }

        [Required, Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [Required, MaxLength(50)]
        public string Specialty { get; set; }

        [Required]
        public int CountSatisfactoryMarks { get; set; }
    }
}
