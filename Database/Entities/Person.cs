using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;

namespace Database.Entities
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50), IndexColumn]
        public string Lastname { get; set; }

        [Required, MaxLength(50), IndexColumn]
        public string Firstname { get; set; }

        [Required, MaxLength(50), IndexColumn]
        public string Patronymic { get; set; }

        [Required, Column(TypeName = "Date")]
        public DateTime Birthdate { get; set; }

        [Required, MaxLength(50)]
        public string Citizenship { get; set; }

        [Required, MaxLength(10)]
        public string Passport { get; set; }

        public bool Workbook { get; set; }

        [Required, MaxLength(250)]
        public string Workplaces { get; set; }

        [Required, MaxLength(250)]
        public string Contacts { get; set; }

        [InverseProperty("Person")]
        public List<EntryExam> EntryExams { get; set; }

        [InverseProperty("Person")]
        public List<Enducation> Enducations { get; set; }

        [Required, IndexColumn]//Unique
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
