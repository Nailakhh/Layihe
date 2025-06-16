using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email və ya istifadəçi adı daxil edin")]
        [Display(Name = "Email və ya İstifadəçi adı")]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Yadda saxla")]
        public bool RememberMe { get; set; }

        // Optional: Captcha və ya digər təhlükəsizlik yoxlamaları üçün 
        // public string CaptchaResponse { get; set; }
    }
}
