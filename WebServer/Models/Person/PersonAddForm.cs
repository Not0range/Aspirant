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
        [Required, MaxLength(50)]
        public string Lastname { get; set; }

        [Required, MaxLength(50)]
        public string Firstname { get; set; }

        [Required, MaxLength(50)]
        public string Patronymic { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required, MaxLength(50)]
        public string Citizenship { get; set; }

        [Required, MaxLength(10)]
        public string Passport { get; set; }

        [Required]
        public bool Workbook { get; set; }

        [Required, MaxLength(250)]
        public string Workplaces { get; set; }

        [Required, MaxLength(250)]
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
