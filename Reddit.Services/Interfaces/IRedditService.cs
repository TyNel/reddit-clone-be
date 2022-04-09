using Reddit.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Services.Interfaces
{
    public interface IRedditService
    {
        Task<int> AddUser(UserAdd user);
    }
}
