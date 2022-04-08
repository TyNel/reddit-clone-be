using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class CommentLiked
    {
        [Required]

        public int LikeDislikeCommentId { get; set; }

        [Required]
        public int CommentLikeDislikeUserId { get; set; }

        [Required]
        [Range(0, 1)]
        public byte CommentIsLike { get; set; }

    }
}
