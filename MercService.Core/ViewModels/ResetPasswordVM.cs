using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class ResetPasswordVM
    {
        [Required(ErrorMessage = "Email daxil edin")]
        [EmailAddress(ErrorMessage = "Düzgün email ünvanı daxil edin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yeni şifrə daxil edin")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifrə ən azı 6 simvol olmalıdır")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrə təsdiqi daxil edin")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrə və təsdiq uyğun deyil")]
        public string ConfirmPassword { get; set; }

       
        public string Token { get; set; }
    }
}
