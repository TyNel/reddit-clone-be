using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class SubRedditAdd
    {
        [Required]
        [StringLength(20, MinimumLength = 1)]

        public string SubName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string SubDescription { get; set; }

        [StringLength(50, MinimumLength = 1)]
        
        public string SubImage { get; set; }

        [StringLength(50, MinimumLength = 1)]

        public string SubIcon { get; set; }

        [StringLength(20, MinimumLength = 1)]

        public string SubCategory { get; set; }

    }
}
