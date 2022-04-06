using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class SubRule
    {
        public int RuleId { get; set; }

        public int RuleParentId { get; set; }

        public string RuleTitle { get; set; }

        public string RuleDescription { get; set; }
    }
}
