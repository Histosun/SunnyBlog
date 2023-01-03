using Microsoft.AspNetCore.Mvc;
using SunnyBlog.Domain;

namespace SunnyBlog.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository ArticleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            ArticleRepository = articleRepository;
        }

        [HttpGet]
        public ActionResult<HotArticleVM[]> GetHotArticles()
        {
            return ArticleRepository.GetHotArticles(e => new HotArticleVM(e.Id, e.Title, e.ViewCount));
        }

        [HttpGet]
        public ActionResult<ArticleListItemVM[]> GetArticleList()
        {
            return ArticleRepository.GetArticleList(e => new ArticleListItemVM(e.Id, e.Title, e.ViewCount));
        }
    }
}