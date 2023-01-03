﻿using Microsoft.Extensions.DependencyInjection;
using SunnyBlog.Domain;

namespace SunnyBlog.Infrastructure
{
    public class ModuleInitializer
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddScoped<IArticleRepository, ArticleRepository>();
        }
    }
}
