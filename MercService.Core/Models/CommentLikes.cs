using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MercService.Core.Models

{
    public class CommentLikes
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }
        //public AppUser User { get; set; }

        public int UserCommentId { get; set; }
        public UserComments UserComment { get; set; }
    }
}
