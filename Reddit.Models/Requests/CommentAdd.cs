using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class CommentAdd
    {
        [Required]
        
        public int CommentUserId { get; set; }

        public int? CommentParentId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 1)]

        public string CommentBody { get; set; }

        [Required]

        public int CommentParentPostId { get; set; }



    }
}
