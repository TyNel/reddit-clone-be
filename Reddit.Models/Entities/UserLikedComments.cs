using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class UserLikedComments
    {
        public int UserId { get; set; }

        public int LikeDislikeCommentId { get; set; }

        public int CommentIsLike { get; set; }
    }
}
