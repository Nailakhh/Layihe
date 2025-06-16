using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercService.Core.ViewModels
{
    public class ReplyVM
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? UserName { get; set; }
        public string? UserAvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int LikeCount { get; set; }

        public int ParentCommentId { get; set; }

    }
}
