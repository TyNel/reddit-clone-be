using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class SubTopicAdd
    {
        [Required]

        public int TopicParentId { get; set; }

        [Required]
        public int TopicTypeId { get; set; }
    }
}
