using Microsoft.Extensions.DependencyInjection;
using SunnyBlog.Domain;
using SunnyBlog.Infrastructure.Repositories;

namespace SunnyBlog.Infrastructure
{
    public class ModuleInitializer
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddMemoryCache();
        }
    }
}
