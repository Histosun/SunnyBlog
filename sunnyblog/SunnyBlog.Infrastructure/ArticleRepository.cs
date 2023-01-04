using Microsoft.EntityFrameworkCore;
using SunnyBlog.Domain;
using SunnyBlog.Domain.Entities;
using System.Linq.Expressions;

namespace SunnyBlog.Infrastructure
{
    public class ArticleRepository : IArticleRepository
    {
        DbSet<Article> Articles;

        public ArticleRepository(BlogDbContext blogDbContext)
        {
            Articles = blogDbContext.Articles;
        }

        public TResult[] GetHotArticles<TResult>(Expression<Func<Article, TResult>> selector)
        {
            return Articles.OrderByDescending(x => x.ViewCount).Where(x => x.Status == 1).Take(10).Select(selector).ToArray();
        }

        public Article GetById(int id)
        {
            return Articles.Where(x => x.Id == id).First();
        }

        public TResult[] GetArticleList<TResult>(int pageNum, Expression<Func<Article, TResult>> selector)
        {
            return Articles.Where(x => x.Status == 1).Skip(pageNum*10).Take(10).Select(selector).ToArray();
        }

        public TResult[] GetArticleListByCategory<TResult>(int pageNum, long categoryId, Expression<Func<Article, TResult>> selector)
        {
            return Articles.Where(x => x.Status == 1 && x.CategoryId == categoryId).Skip(pageNum * 10).Take(10).Select(selector).ToArray();
        }
    }
}
