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
            return Articles.OrderByDescending(x => x.ViewCount).Where(x => x.Status == null ? false : x.Status =='0').Take(10).Select(selector).ToArray();
        }

        public Article GetById(int id)
        {
            return Articles.Where(x => x.Id == id).First();
        }

        public IEnumerable<TResult> GetHotArticles<TResult>()
        {
            throw new NotImplementedException();
        }

        public TResult[] GetArticleList<TResult>(Expression<Func<Article, TResult>> selector)
        {
            throw new NotImplementedException();
        }
    }
}
