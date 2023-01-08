using Microsoft.Extensions.DependencyInjection;
using SunnyBlog.Domain;
using SunnyBlog.Infrastructure.Repositories;
using SunnyBlog.Domain.Services;
using SunnyCommons.Auth.Token;

namespace SunnyBlog.Infrastructure
{
    public class ModuleInitializer
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIdRepository, IdRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IdService>();
            services.AddMemoryCache();
        }
    }
}
