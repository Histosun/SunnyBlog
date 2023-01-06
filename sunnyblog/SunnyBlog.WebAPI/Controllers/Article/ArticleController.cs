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
        public ActionResult<ArticleListItemVM[]> GetArticleList([FromQuery]int? pageNum)
        {
            int pageNr = pageNum ?? 1;
            var articleList = ArticleRepository.GetArticleList(pageNr, e => new ArticleListItemVM(e.Id, e.Title, e.Summary, e.ViewCount, e.CategoryId, e.CreateTime));
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
            string? categoryName = GetCategoryNameById(categoryId);
            if(categoryName == null) return null;
            return ArticleRepository.GetArticleListByCategory(pageNum, categoryId, e => new ArticleListItemVM(e.Id, e.Title, e.Summary, e.ViewCount, null, e.CreateTime, categoryName)); ;
        }

        [HttpGet("{id}")]
        public ActionResult<ArticleDetailVM>? GetArticleDetail([FromRoute] long id)
        {
            return ArticleRepository.GetArticleDetail(id, e => new ArticleDetailVM(e.Title, e.Content, e.ViewCount, e.CreateTime));
        }

        private string? GetCategoryNameById(long? Id)
        {
            if (Id == null)
                return null;
            Category result;
            if (MemoryCache.TryGetValue($"Category.ID.${Id}", out result))
                return result.Name;
            result = CategoryRepository.GetById((long)Id);
            if (result == null)
                return null;
            MemoryCache.Set($"Category.ID.${Id}", result, TimeSpan.FromDays(7));
            return result.Name;
        }
    }
}