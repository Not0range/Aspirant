using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    [Table("Exams")]
    public class Exam
    {
        public int Id { get; set; }

        [Required]
        public int AspirantId { get; set; }

        [ForeignKey("AspirantId")]
        public Aspirant Aspirant { get; set; }

        [Required, Column(TypeName = "Date")]
        public DateTime date { get; set; }

        [Required]
        public ExamType ExamType { get; set; }

        [Required, MaxLength(50)]
        public string Subject { get; set; }
        
        public int? TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }

        [Required]
        public int Result { get; set; }
    }

    public enum ExamType : int
    {
        Offset,
        OffsetWithMark,
        Exam
    }
}
