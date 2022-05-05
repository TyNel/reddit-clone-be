using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class PostSearched : Post
    {
        public string SubIcon { get; set; }

        public int SubId { get; set; }

    }
}
