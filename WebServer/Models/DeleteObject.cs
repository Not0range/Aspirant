using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class DeleteObject
    {
        [Required]
        public int Id { get; set; }
    }
}
