using MercService.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.Models
{
    public class UserComments
    {
        public int Id { get; set; }

        public string? Text { get; set; }
  
        public int? ModelProblemId { get; set; }
        public SubModelProblem? ModelProblem { get; set; }

        public int? MechanicId { get; set; }
        public Mechanic? Mechanic { get; set; }

        public int Rating { get; set; }

        public string? UserName { get; set; }

        public string? UserId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public int? ParentCommentId { get; set; }
        public UserComments? ParentComment { get; set; }

        public ICollection<UserComments> Replies { get; set; } = new List<UserComments>();

        public string? UserAvatarUrl { get; set; }

        public List<CommentLikes> Likes { get; set; } = new();

        public int LikeCount => Likes?.Count ?? 0;

        public string? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }
    }
}
