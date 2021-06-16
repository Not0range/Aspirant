using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class LoginForm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Имя пользователя' должно быть заполнено")]
        public string Login { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Пароль' должно быть заполнено")]
        public string Password { get; set; }
    }
}
