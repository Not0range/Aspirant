using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class AspirantAddForm
    {
        [Required, MaxLength(50)]
        public string ForeignLanguage { get; set; }

        [Required, MaxLength(30)]
        public string EnducationForm { get; set; }

        [Required, MaxLength(50)]
        public string EnducationDirection { get; set; }

        [Required, MaxLength(50)]
        public string Specialty { get; set; }

        [Required, MaxLength(50)]
        public string Cathedra { get; set; }

        [Required, MaxLength(50)]
        public string Faculty { get; set; }

        [Required, MaxLength(50)]
        public string Decree { get; set; }

        [Required, MaxLength(100)]
        public string DissertationTheme { get; set; }

        public Aspirant GetAspirant()
        {
            return new Aspirant
            {
                ForeignLanguage = ForeignLanguage,
                EnducationForm = EnducationForm,
                EnducationDirection = EnducationDirection,
                Specialty = Specialty,
                Cathedra = Cathedra,
                Faculty = Faculty,
                Decree = Decree,
                DissertationTheme = DissertationTheme
            };
        }
    }
}
