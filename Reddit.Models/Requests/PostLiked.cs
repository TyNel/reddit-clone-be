using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class PostLiked
    {
        [Required]

        public int LikeDislikePostId { get; set; }

        [Required]
        public int LikeDislikeUserId { get; set; }

        [Required]
        [Range(0, 1)]
        public byte PostIsLike { get; set; }

       
    }
}
