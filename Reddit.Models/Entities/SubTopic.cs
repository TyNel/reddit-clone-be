using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class SubTopic
    {
        public int SubTopicId { get; set; }
        
        public int TopicParentId { get; set; }

        public int TopicTypeId { get; set; }
    }
}
