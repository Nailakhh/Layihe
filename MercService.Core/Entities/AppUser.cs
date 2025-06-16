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



        public List<UserComments> Comments { get; set; }
        public ICollection<CommentLikes> CommentLikes { get; set; }
    }
}
