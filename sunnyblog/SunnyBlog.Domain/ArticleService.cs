namespace SunnyBlog.Domain
{
    public class ArticleService
    {
        IArticleRepository articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }
    }
}
