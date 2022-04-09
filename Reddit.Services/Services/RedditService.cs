using Dapper;
using Microsoft.Extensions.Configuration;
using Reddit.Models.Entities;
using Reddit.Models.Requests;
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
                parameter.Add("@password", user.Password);

                await Connection.QueryAsync<User>(proc, parameter, commandType: CommandType.StoredProcedure);

                int newUser = parameter.Get<int>("@userId");

                return newUser;

            }
        }
   
    }
}
