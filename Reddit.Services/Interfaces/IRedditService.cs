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

        Task<PostSearched> AddPost(PostAdd post);

        Task<IEnumerable<SubNames>> GetSubNames();

        Task<SubReddit> GetSubReddit(string subName);

        Task<IEnumerable<Post>> GetPosts(int pageNumber, int pageSize);

        Task<IEnumerable<Post>> GetSubPosts(int subId);

        Task<IEnumerable<Comment>> GetComments(int postId);

        Task<PostLike> PostLike(PostLiked post);

        Task<CommentLike> CommentLike(CommentLiked comment);

        Task<IEnumerable<UserLikedComments>> GetUserCommentLikes(int postId, int userId);

        Task<IEnumerable<PostSearched>> SearchPosts(string query);

        Task<IEnumerable<SubReddit>> GetRandomSubs();

        Task<IEnumerable<PostSearched>> GetTrendingPosts();



    }
}
