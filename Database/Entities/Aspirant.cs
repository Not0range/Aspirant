using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;

namespace Database.Entities
{
    [Table("Aspirants")]
    public class Aspirant
    {
        [Key]
        public int Id { get; set; }

        [Required, IndexColumn]//Unique
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [Required, MaxLength(50)]
        public string ForeignLanguage { get; set; }

        [Required, MaxLength(30)]
        public string EnducationForm { get; set; }

        [Required, MaxLength(50)]
        public string EnducationDirection { get; set; }

        [Required, MaxLength(50)]
        public string Specialty { get; set; }

        [Required, MaxLength(50)]
        public string Cathedra { get; set; }

        [Required, MaxLength(50)]
        public string Faculty { get; set; }

        [Required, MaxLength(50)]
        public string Decree { get; set; }

        [Required, MaxLength(100)]
        public string DissertationTheme { get; set; }

        [InverseProperty("Aspirant")]
        public List<Exam> Exams { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}
