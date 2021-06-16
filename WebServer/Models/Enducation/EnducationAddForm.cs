using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class EnducationAddForm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Уровень образования' должно быть заполнено"), MaxLength(50)]
        public string Level { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Документ' должно быть заполнено"), MaxLength(150)]
        public string Document { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Дата окончания' должно быть заполнено")]
        public DateTime EndDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Специальность' должно быть заполнено"), MaxLength(50)]
        public string Specialty { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'На отлично' должно быть заполнено")]
        public bool Excellent { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Кол-во удовлетворительных оценок' должно быть заполнено")]
        public int CountSatisfactoryMarks { get; set; }

        public Enducation GetEnducation()
        {
            return new Enducation
            {
                Level = Level,
                Document = Document,
                EndDate = EndDate,
                Specialty = Specialty,
                Excellent = Excellent,
                CountSatisfactoryMarks = CountSatisfactoryMarks
            };
        }
    }
}
