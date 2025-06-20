using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }



        [RegularExpression(@"^\+994\s?\d{3}\s?\d{2}\s?\d{2}\s?\d{2}$", ErrorMessage = "Format: +994 997 04 02 11")]

        [Required(ErrorMessage = "Telefon nömrəsi boş ola bilməz.")]


        public string Phone { get; set; }

    }

}
