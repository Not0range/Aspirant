using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class PersonEditForm
    {
        [MaxLength(50)]
        public string Lastname { get; set; }

        [MaxLength(50)]
        public string Firstname { get; set; }

        [MaxLength(50)]
        public string Patronymic { get; set; }

        public DateTime? Birthdate { get; set; }

        [MaxLength(50)]
        public string Citizenship { get; set; }

        [MaxLength(10)]
        public string Passport { get; set; }

        public bool? Workbook { get; set; }

        [MaxLength(250)]
        public string Workplaces { get; set; }

        [MaxLength(250)]
        public string Contacts { get; set; }

        public Person GetPerson(Person person)
        {
            if (string.IsNullOrWhiteSpace(Lastname))
                person.Lastname = Lastname;
            if (string.IsNullOrWhiteSpace(Firstname))
                person.Firstname = Firstname;
            if (string.IsNullOrWhiteSpace(Patronymic))
                person.Patronymic = Patronymic;
            if (Birthdate.HasValue)
                person.Birthdate = Birthdate.Value;
            if (string.IsNullOrWhiteSpace(Citizenship))
                person.Citizenship = Citizenship;
            if (string.IsNullOrWhiteSpace(Passport))
                person.Passport = Passport;
            if (Workbook.HasValue)
                person.Workbook = Workbook.Value;
            if (string.IsNullOrWhiteSpace(Workplaces))
                person.Workplaces = Workplaces;
            if (string.IsNullOrWhiteSpace(Contacts))
                person.Contacts = Contacts;
            return person;
        }
    }
}
