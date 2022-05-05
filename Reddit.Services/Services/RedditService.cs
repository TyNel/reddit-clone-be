using Dapper;
using Microsoft.Extensions.Configuration;
using Reddit.Models.Entities;
using Reddit.Models.Requests;
using Reddit.Services.CommonMethods;
using Reddit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Services.Services
{
    public class RedditService : IRedditService
    {
        private readonly IConfiguration _config;

        User _user = new User();
        Comment _comment = new Comment();
        CommentLike _commentLiked = new CommentLike();
        Post _post = new Post();
        PostLike _postLiked = new PostLike();
        SubMember _subMember = new SubMember();
        SubReddit _subReddit = new SubReddit();
        SubRule _subRule = new SubRule();
        SubTopic _subTopic = new SubTopic();
        SubNames _subName = new SubNames();
        UserLikedComments _userVotes = new UserLikedComments();

        public RedditService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("Default"));
            }
        }

        public async Task<int> AddUser(UserAdd user)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Users_Add]";
                var parameter = new DynamicParameters();

                parameter.Add("userId", 0, DbType.Int32, ParameterDirection.Output);
                parameter.Add("@userName", user.UserName);
                parameter.Add("@email", user.Email);
                parameter.Add("@password", PwManager.Encrypt(user.Password));

                await Connection.QueryAsync<User>(proc, parameter, commandType: CommandType.StoredProcedure);

                int newUser = parameter.Get<int>("@userId");

                return newUser;

            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_User_GetByEmail]";
                var parameter = new DynamicParameters();

                parameter.Add("@email", email);

                var response = await Connection.QueryAsync<User>(proc, parameter, commandType: CommandType.StoredProcedure);

                _user = response.FirstOrDefault();

                return _user;
            }
        }

        public async Task<User> GetUserByUsername(string username)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_User_GetByUsername]";
                var parameter = new DynamicParameters();

                parameter.Add("@userName", username);

                var response = await Connection.QueryAsync<User>(proc, parameter, commandType: CommandType.StoredProcedure);

                _user = response.FirstOrDefault();

                return _user;
            }
        }

        public async Task<User> UserLogin(UserLogin user)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Users_Login]";
                var parameter = new DynamicParameters();

                parameter.Add("@username", user.Username);
                parameter.Add("@password", PwManager.Encrypt(user.Password));

                var response = await Connection.QueryAsync<User>(proc, parameter, commandType: CommandType.StoredProcedure);

                _user = response.FirstOrDefault();

                return _user;
            }
        }

        public async Task<Comment> AddComment(CommentAdd comment)
        {
            using(IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Comments_ADD]";
                var parameter = new DynamicParameters();

                parameter.Add("@commentId", 0, DbType.Int32, ParameterDirection.Output);
                parameter.Add("@commentUserId", comment.CommentUserId);
                parameter.Add("@commentParentId", comment.CommentParentId);
                parameter.Add("@commentBody", comment.CommentBody);
                parameter.Add("@commentParentPostId", comment.CommentParentPostId);

                var response = await Connection.QueryAsync<Comment>(proc, parameter, commandType: CommandType.StoredProcedure);

                _comment = response.FirstOrDefault();

                return _comment;
            }
        }

        public async Task<Post> AddPost(PostAdd post)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Posts_ADD]";
                var parameter = new DynamicParameters();

                parameter.Add("@postId", 0, DbType.Int32, ParameterDirection.Output);
                parameter.Add("@postAuthor", post.PostAuthor);
                parameter.Add("@postCommunity", post.PostCommunity);
                parameter.Add("@postTitle", post.PostTitle);
                parameter.Add("@postBodyText", post.PostBody);
                parameter.Add("@postImageUrl", post.PostImageUrl);
                parameter.Add("@postLink", post.PostLink);
               

                var response = await Connection.QueryAsync<Post>(proc, parameter, commandType: CommandType.StoredProcedure);

                _post = response.FirstOrDefault();

                return _post;
            }
        }

        public async Task<PostLike> PostLike(PostLiked post)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Posts_Like_Dislike_ADD]";
                var parameter = new DynamicParameters();

                parameter.Add("@postLikeDislikeId", 0, DbType.Int32, ParameterDirection.Output);
                parameter.Add("@likeDislikePostId", post.LikeDislikePostId);
                parameter.Add("@postLikeDislikeUserId", post.LikeDislikeUserId);
                parameter.Add("@postIsLike", post.PostIsLike);
                
                var response = await Connection.QueryAsync<PostLike>(proc, parameter, commandType: CommandType.StoredProcedure);

                _postLiked = response.FirstOrDefault();

                return _postLiked;
            }
        }
        public async Task<CommentLike> CommentLike(CommentLiked comment)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Comments_Like_Dislike_ADD]";
                var parameter = new DynamicParameters();

                parameter.Add("@commentLikeDislikeId", 0, DbType.Int32, ParameterDirection.Output);
                parameter.Add("@likeDislikeCommentId", comment.LikeDislikeCommentId);
                parameter.Add("@commentLikeDislikeUserId", comment.CommentLikeDislikeUserId);
                parameter.Add("@commentIsLike", comment.CommentIsLike);

                var response = await Connection.QueryAsync<CommentLike>(proc, parameter, commandType: CommandType.StoredProcedure);

                _commentLiked = response.FirstOrDefault();

                return _commentLiked;
            }
        }

        public async Task<IEnumerable<SubNames>> GetSubNames()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_SubReddits_GETNAMES]";

                var response = await Connection.QueryAsync<SubNames>(proc, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

        public async Task<SubReddit> GetSubReddit(string subName)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_SubReddits_GET]";
                var parameter = new DynamicParameters();

                parameter.Add("@subName", subName);

                var response = await Connection.QueryAsync<SubReddit>(proc, parameter, commandType: CommandType.StoredProcedure);

                _subReddit = response.FirstOrDefault();

                return _subReddit;

            }
        }

        public async Task<IEnumerable<UserLikedComments>> GetUserCommentLikes(int postId, int userId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_User_CommentVotes_GET]";
                var parameter = new DynamicParameters();

                parameter.Add("@postId", postId);
                parameter.Add("@userId", userId);


                var response = await Connection.QueryAsync<UserLikedComments>(proc, parameter, commandType: CommandType.StoredProcedure);

                return response.ToList();

        
            }
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Posts_GET]";

                var response = await Connection.QueryAsync<Post>(proc, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

        public async Task<IEnumerable<Post>> GetSubPosts(int subId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_SubReddits_Posts_GET]";
                var parameter = new DynamicParameters();

                parameter.Add("@subId", subId);
                
                var response = await Connection.QueryAsync<Post>(proc, parameter, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

        public async Task<IEnumerable<SubReddit>> GetRandomSubs()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_SubReddits_GET_RANDOM]";
            
                var response = await Connection.QueryAsync<SubReddit>(proc, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

        public async Task<IEnumerable<PostSearched>> SearchPosts(string query)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Posts_Search]";
                var parameter = new DynamicParameters();

                parameter.Add("@query", query);

                var response = await Connection.QueryAsync<PostSearched>(proc, parameter, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

        public async Task<IEnumerable<Comment>> GetComments(int postId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                var proc = "[dbo].[R_Comments_GET]";

                var parameter = new DynamicParameters();

                parameter.Add("@commentParentPostId", postId);

                var response = await Connection.QueryAsync<Comment>(proc, parameter, commandType: CommandType.StoredProcedure);

                return response.ToList();
            }
        }

    }
}
