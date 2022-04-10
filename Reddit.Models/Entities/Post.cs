﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class Post
    {
        public int PostId { get; set; }

        public string PostAuthor { get; set; }

        public int PostCommunity { get; set; }

        public string PostTitle { get; set; }

        public string PostBodyText { get; set; }

        public string PostImage { get; set; }

        public string PostLink { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }
    }
}
