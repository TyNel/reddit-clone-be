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

        public int PostIsLike { get; set; }

        public int VoteCount { get; set; }

    }
}
