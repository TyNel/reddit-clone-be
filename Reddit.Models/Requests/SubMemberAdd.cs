using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class SubMemberAdd
    {
        [Required]

        public int SubParentId { get; set; }

        [Required]
        public int SubMemberId { get; set; }
    }
}
