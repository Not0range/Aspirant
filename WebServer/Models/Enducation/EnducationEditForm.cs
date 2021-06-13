using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class EnducationEditForm
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Level { get; set; }

        [MaxLength(150)]
        public string Document { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(50)]
        public string Specialty { get; set; }

        public bool? Excellent { get; set; }

        public int? CountSatisfactoryMarks { get; set; }

        public Enducation GetEnducation(Enducation enducation)
        {
            if (string.IsNullOrWhiteSpace(Level))
                enducation.Level = Level;
            if (string.IsNullOrWhiteSpace(Document))
                enducation.Document = Document;
            if (EndDate.HasValue)
                enducation.EndDate = EndDate.Value;
            if (string.IsNullOrWhiteSpace(Specialty))
                enducation.Specialty = Specialty;
            if (Excellent.HasValue)
                enducation.Excellent = Excellent.Value;
            if (CountSatisfactoryMarks.HasValue)
                enducation.CountSatisfactoryMarks = CountSatisfactoryMarks.Value;
            return enducation;
        }
    }
}
