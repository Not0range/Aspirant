using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Models
{
    public class RegistrationForm
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Имя пользователя' должно быть заполнено")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Электронная почта' должно быть заполнено")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Пароль' должно быть заполнено")]
        [MaxLength(32, ErrorMessage = "Пароль не может быть длинее 32-х символов")]
        [MinLength(6, ErrorMessage = "Пароль не может быть короче 6-ти символов")]
        public string Password { get; set; }
    }
}
