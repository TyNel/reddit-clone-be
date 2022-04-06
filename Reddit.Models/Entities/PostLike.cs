using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class PostLike
    {
        public int LikeDislikePostId { get; set; }

        public int PostLikeDislikeUserId { get; set; }

        public byte PostIsLike { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
