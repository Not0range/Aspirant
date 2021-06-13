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
        [Required, MaxLength(50)]
        public string Level { get; set; }

        [Required, MaxLength(150)]
        public string Document { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required, MaxLength(50)]
        public string Specialty { get; set; }

        [Required]
        public bool Excellent { get; set; }

        [Required]
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
