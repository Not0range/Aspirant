using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    [Table("EntryExams")]
    public class EntryExam
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [Required, Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required, MaxLength(50)]
        public string Subject { get; set; }
        [Required]
        public int TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        [Required]
        public int Result { get; set; }
    }
}
