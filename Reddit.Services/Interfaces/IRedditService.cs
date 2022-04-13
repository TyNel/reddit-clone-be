using Reddit.Models.Entities;
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

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByUsername(string username);

        Task<User> UserLogin(UserLogin user);

        Task<Comment> AddComment(CommentAdd comment);

        Task<Post> AddPost(PostAdd post);

        Task<IEnumerable<SubNames>> GetSubNames();

    }
}
