using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class SubRuleAdd
    {
        [Required]
        public int RuleParentId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]

        public string RuleTitle { get; set; }

       
        [StringLength(100, MinimumLength = 1)]

        public string RuleDescription { get; set; }
    }
}
