using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class EntryExamEditForm
    {
        [Required]
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        [MaxLength(50)]
        public string Subject { get; set; }
        
        public int? TeacherId { get; set; }

        public int? Result { get; set; }

        public EntryExam GetExam(EntryExam exam)
        {
            if (Date.HasValue)
                exam.Date = Date.Value;
            if (string.IsNullOrWhiteSpace(Subject))
                exam.Subject = Subject;
            if (TeacherId.HasValue)
                exam.TeacherId = TeacherId.Value;
            if (Result.HasValue)
                exam.Result = Result.Value;
            return exam;
        }
    }
}
