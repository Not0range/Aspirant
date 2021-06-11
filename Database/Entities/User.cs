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
    [Table("Users")]
    public class User
    {
        [PrimaryKey]
        [IndexColumn]
        public int UserId { get; set; }

        [Required]
        [IndexColumn]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [IndexColumn]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(32)]
        public string Password { get; set; }
    }
}
