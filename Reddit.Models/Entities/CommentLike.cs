using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class CommentLike
    {
        public int LikeDislikeCommentId { get; set; }

        public int CommentLikeDislikeUserId { get; set; }

        public int CommentIsLike { get; set; }

        public int VoteCount { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
