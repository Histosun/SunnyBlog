namespace SunnyBlog.Domain.Services
{
    public class ArticleService
    {
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        public ArticleService(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }
    }
}
