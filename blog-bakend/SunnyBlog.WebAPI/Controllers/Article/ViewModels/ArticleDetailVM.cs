using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SunnyBlog.WebAPI.Controllers
{
    public class ArticleDetailVM
    {
        public string Title { get; init; }
        public string Content { get; init; }
        public long ViewCount { get; init; }
        public DateTime Created { get; init; }
        public ArticleDetailVM(string Title, string Content, long ViewCount, DateTime Created)
        {
            this.Title = Title;
            this.Content = Content;
            this.ViewCount = ViewCount;
            this.Created = Created;
        }
    }
}
