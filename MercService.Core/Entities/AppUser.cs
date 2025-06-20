using MercService.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Entities
{
    public class AppUser : IdentityUser
    {
          public string Name { get; set; }
        public string Surname { get; set; }
 


        public string? FullName => $"{Name} {Surname}";

        public string? AvatarUrl { get; set; }

        public DateTime? BirthDate { get; set; }

        public string? Bio { get; set; }

        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

        public List<UserComments>? Comments { get; set; } = new();

        public List<CommentLikes>? CommentLikes { get; set; } = new();
    }
}
