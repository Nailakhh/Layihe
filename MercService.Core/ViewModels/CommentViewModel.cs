using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikesCount { get; set; }
        public bool IsLikedByCurrentUser { get; set; }
        public List<ReplyVM> Replies { get; set; } = new();
        public string? UserAvatarUrl { get; set; }
    }
}
