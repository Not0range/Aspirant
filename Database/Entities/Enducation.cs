using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    [Table("Enducations")]
    public class Enducation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [Required, MaxLength(50)]
        public string Level { get; set; }

        [Required, MaxLength(150)]
        public string Document { get; set; }

        [Required, Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }

        [Required, MaxLength(50)]
        public string Specialty { get; set; }

        [Required]
        public bool Excellent { get; set; }

        [Required]
        public int CountSatisfactoryMarks { get; set; }
    }
}
