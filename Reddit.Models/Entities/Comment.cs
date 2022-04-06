﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int CommentUserId { get; set; }

        public int CommentParentId { get; set; }

        public int CommentPostParentId { get; set; }

        public string CommentBody { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

    }
}
