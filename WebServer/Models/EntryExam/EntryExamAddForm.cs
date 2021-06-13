using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class EntryExamAddForm
    {
        [Required]
        public DateTime Date { get; set; }

        [Required, MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int Result { get; set; }

        public EntryExam GetExam()
        {
            return new EntryExam
            {
                Date = Date,
                Subject = Subject,
                TeacherId = TeacherId,
                Result = Result
            };
        }
    }
}
