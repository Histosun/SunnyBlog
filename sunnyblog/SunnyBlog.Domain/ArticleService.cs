namespace SunnyBlog.Domain
{
    public class ArticleService
    {
        IArticleRepository articleRepository;
        ICategoryRepository categoryRepository;
        public ArticleService(IArticleRepository articleRepository, ICategoryRepository categoryRepository)
        {
            this.articleRepository = articleRepository;
            this.categoryRepository = categoryRepository;
        }
    }
}
