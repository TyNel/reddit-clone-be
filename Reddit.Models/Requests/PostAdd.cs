using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class PostAdd
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string PostAuthor { get; set; }

        [Required]
        public int PostCommunity { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 1)]

        public string PostTitle { get; set; }

        [StringLength(1000, MinimumLength = 0)]

        public string PostBody { get; set; }

        [StringLength(300, MinimumLength = 1)]

        public string PostImageUrl { get; set; }

        [StringLength(300, MinimumLength = 2)]
        public string PostLink { get; set; }
    }
}
