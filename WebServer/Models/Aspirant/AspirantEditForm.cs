using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class AspirantEditForm
    {
        [MaxLength(50)]
        public string ForeignLanguage { get; set; }

        [MaxLength(30)]
        public string EnducationForm { get; set; }

        [MaxLength(50)]
        public string EnducationDirection { get; set; }

        [MaxLength(50)]
        public string Specialty { get; set; }

        [MaxLength(50)]
        public string Cathedra { get; set; }

        [MaxLength(50)]
        public string Faculty { get; set; }

        [MaxLength(50)]
        public string Decree { get; set; }

        [MaxLength(100)]
        public string DissertationTheme { get; set; }

        public int? TeacherId { get; set; }

        public Aspirant GetAspirant(Aspirant aspirant)
        {
            if (!string.IsNullOrWhiteSpace(ForeignLanguage))
                aspirant.ForeignLanguage = ForeignLanguage;
            if (!string.IsNullOrWhiteSpace(EnducationForm))
                aspirant.EnducationForm = EnducationForm;
            if (!string.IsNullOrWhiteSpace(EnducationDirection))
                aspirant.EnducationDirection = EnducationDirection;
            if (!string.IsNullOrWhiteSpace(Specialty))
                aspirant.Specialty = Specialty;
            if (!string.IsNullOrWhiteSpace(Cathedra))
                aspirant.Cathedra = Cathedra;
            if (!string.IsNullOrWhiteSpace(Faculty))
                aspirant.Faculty = Faculty;
            if (!string.IsNullOrWhiteSpace(Decree))
                aspirant.Decree = Decree;
            if (!string.IsNullOrWhiteSpace(DissertationTheme))
                aspirant.DissertationTheme = DissertationTheme;
            if (TeacherId.HasValue)
                aspirant.TeacherId = TeacherId.Value;
            return aspirant;
        }
    }
}
