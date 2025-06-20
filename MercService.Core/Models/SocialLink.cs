using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class SocialLink
    {
        public int Id { get; set; }
        [Required]
        public string Platform { get; set; }
        // "Facebook", "Instagram" və s.

        [Required]
        [Url]
        public string Url { get; set; }
    }
}
