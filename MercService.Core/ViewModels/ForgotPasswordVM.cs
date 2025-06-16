using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Email daxil edin")]
        [EmailAddress(ErrorMessage = "Düzgün email ünvanı daxil edin")]
        public string Email { get; set; }
    }
}
