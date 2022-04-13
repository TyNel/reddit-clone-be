using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Models.Requests
{
    public class UserLogin
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]

        public string Username { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 8)]

        public string Password { get; set; }
    }
}
