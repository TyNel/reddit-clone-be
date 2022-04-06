using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Entities
{
    public class SubReddit
    {
       public int SubId { get; set; }

       public string SubName { get; set; }

       public string SubDescription { get; set; }
        
       public string SubImage { get; set; }

       public string SubIcon { get; set; }

       public string SubCategory { get; set; }

       public DateTime DateAdded { get; set; }
    }
}
