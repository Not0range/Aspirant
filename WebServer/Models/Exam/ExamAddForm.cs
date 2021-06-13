using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class ExamAddForm
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public ExamType ExamType { get; set; }

        [Required, MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int Result { get; set; }

        public Exam GetExam()
        {
            return new Exam
            {
                Date = Date,
                ExamType = ExamType,
                Subject = Subject,
                TeacherId = TeacherId,
                Result = Result
            };
        }
    }
}
