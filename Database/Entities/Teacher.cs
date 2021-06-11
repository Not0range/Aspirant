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
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50), IndexColumn]
        public string Lastname { get; set; }

        [Required, MaxLength(50), IndexColumn]
        public string Firstname { get; set; }

        [Required, MaxLength(50), IndexColumn]
        public string Patronymic { get; set; }

        [Required, MaxLength(50)]
        public string Cathedra { get; set; }

        [Required, MaxLength(50)]
        public string Faculty { get; set; }

        [InverseProperty("Teacher")]
        public List<Aspirant> Aspirants { get; set; }
    }
}
