using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class PersonAddForm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Фамилия' должно быть заполнено"), MaxLength(50)]
        public string Lastname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Имя' должно быть заполнено"), MaxLength(50)]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Отчество' должно быть заполнено"), MaxLength(50)]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Дата рождения' должно быть заполнено")]
        public DateTime Birthdate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Гражданство' должно быть заполнено"), MaxLength(50)]
        public string Citizenship { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Документ' должно быть заполнено"), MaxLength(10)]
        public string Passport { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Наличие трудовой книжки' должно быть заполнено")]
        public bool Workbook { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Место работы' должно быть заполнено"), MaxLength(250)]
        public string Workplaces { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Контактные данные' должно быть заполнено"), MaxLength(250)]
        public string Contacts { get; set; }

        public Person GetPerson()
        {
            return new Person
            {
                Lastname = Lastname,
                Firstname = Firstname,
                Patronymic = Patronymic,
                Birthdate = Birthdate,
                Citizenship = Citizenship,
                Passport = Passport,
                Workbook = Workbook,
                Workplaces = Workplaces,
                Contacts = Contacts
            };
        }
    }
}
