using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class ProfileEditVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }

        public string? Bio { get; set; }
        public string? Address { get; set; }
        public DateTime? BirthDate { get; set; }

        public IFormFile? Avatar { get; set; }

        public string? ExistingAvatarUrl { get; set; }
    }

}
