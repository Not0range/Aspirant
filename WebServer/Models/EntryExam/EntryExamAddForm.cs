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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Дата и время проведения' должно быть заполнено")]
        public DateTime Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Предмет' должно быть заполнено"), MaxLength(50)]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Преподаватель' должно быть заполнено")]
        public int TeacherId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Резульат' должно быть заполнено")]
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
