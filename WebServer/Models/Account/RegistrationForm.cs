using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class RegistrationForm
    {
        [Required]
        public string Username { get; set; }

        [Required, RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }

        [Required, MaxLength(32), MinLength(6)]
        public string Password { get; set; }
    }
}
