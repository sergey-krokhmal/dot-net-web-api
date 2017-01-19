using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternalMoney.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
 
        [Required]
        [StringLength(100, ErrorMessage = "{0} должен быть длинной не меннее {2} символо", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
 
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "{0} отличается от пароля")]
        public string ConfirmPassword { get; set; }
    }
}