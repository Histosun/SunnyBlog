using SunnyBlog.Domain.Entities;
using System.Linq.Expressions;

namespace SunnyBlog.Domain
{
    public interface IArticleRepository
    {
        public Article GetById(int id);
        public TResult[] GetHotArticles<TResult>(Expression<Func<Article, TResult>> selector);
        public TResult[] GetArticleList<TResult>(Expression<Func<Article, TResult>> selector);
    }
}
