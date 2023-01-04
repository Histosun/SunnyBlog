using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SunnyBlog.Domain;
using SunnyBlog.Domain.Entities;

namespace SunnyBlog.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository ArticleRepository;
        private readonly ICategoryRepository CategoryRepository;
        private readonly IMemoryCache MemoryCache;

        public ArticleController(IArticleRepository articleRepository, ICategoryRepository categoryRepository, IMemoryCache memoryCache)
        {
            ArticleRepository = articleRepository;
            CategoryRepository = categoryRepository;
            MemoryCache = memoryCache;
        }

        [HttpGet]
        public ActionResult<HotArticleVM[]> GetHotArticles()
        {
            return ArticleRepository.GetHotArticles(e => new HotArticleVM(e.Id, e.Title, e.ViewCount));
        }

        [HttpGet]
        public ActionResult<ArticleListItemVM[]> GetArticleList([FromQuery]int pageNum)
        {
            var articleList = ArticleRepository.GetArticleList(pageNum, e => new ArticleListItemVM(e.Id, e.Title, e.Summary, e.ViewCount, e.CategoryId, e.CreateTime));
            Func<long?, string?> GetCategoryNameById = Id =>
            {
                if(Id == null)
                    return null;
                Category result;
                if (MemoryCache.TryGetValue($"Category.ID.${Id}", out result))
                    return result.Name;
                result = CategoryRepository.GetById((long)Id);
                if (result == null)
                    return null;
                MemoryCache.Set($"Category.ID.${Id}", result, new DateTime(100000L));
                return result.Name;
            };
            articleList.All(it =>
            {
                it.CategoryName = GetCategoryNameById(it.CategoryId);
                return true;
            });
            return articleList;
        }

        [HttpGet]
        public ActionResult<ArticleListItemVM[]>? GetArticleListByCategory([FromQuery] int pageNum, [FromQuery] long categoryId)
        {
            Category category = MemoryCache.GetOrCreate($"Category.ID.${categoryId}", e => CategoryRepository.GetById(categoryId));
            if(category == null) return null;
            return ArticleRepository.GetArticleListByCategory(pageNum, categoryId, e => new ArticleListItemVM(e.Id, e.Title, e.Summary, e.ViewCount, null, e.CreateTime, category.Name)); ;
        }
    }
}