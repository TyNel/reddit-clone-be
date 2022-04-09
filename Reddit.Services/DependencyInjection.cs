using Microsoft.Extensions.DependencyInjection;
using Reddit.Services.Interfaces;
using Reddit.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reddit.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructor(this IServiceCollection services)
        {
            services.AddTransient<IRedditService, RedditService>();

            return services;
        }
    }
}
