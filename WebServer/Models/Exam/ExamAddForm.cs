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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Дата и время проведения' должно быть заполнено")]
        public DateTime Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Тип' должно быть заполнено")]
        public ExamType ExamType { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Предмет' должно быть заполнено"), MaxLength(50)]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Преподаватель' должно быть заполнено")]
        public int TeacherId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Результат' должно быть заполнено")]
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
