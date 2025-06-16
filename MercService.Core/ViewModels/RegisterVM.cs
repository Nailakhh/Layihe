using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class RegisterVM
    {

        [Required(ErrorMessage = "Ad daxil edin")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad 2 ilə 50 simvol arasında olmalıdır")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad daxil edin")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Soyad 2 ilə 100 simvol arasında olmalıdır")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "İstifadəçi adı daxil edin")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "İstifadəçi adı 3 ilə 50 simvol arasında olmalıdır")]
        [RegularExpression(@"^[a-zA-Z0-9._-]{3,50}$", ErrorMessage = "İstifadəçi adı yalnız hərflər, rəqəmlər, nöqtə, alt xətt və tiredən ibarət ola bilər")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email ünvanı daxil edin")]
        [EmailAddress(ErrorMessage = "Düzgün email ünvanı daxil edin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifrə daxil edin")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifrə ən azı 6 simvol olmalıdır")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifrə təsdiqini daxil edin")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifrə və təsdiq uyğun deyil")]
        public string ConfirmPassword { get; set; }
    }
}
