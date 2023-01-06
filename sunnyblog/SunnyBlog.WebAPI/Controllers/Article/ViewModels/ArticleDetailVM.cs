using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SunnyBlog.WebAPI.Controllers
{
    public class ArticleDetailVM
    {
        public long Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public long ViewCount { get; init; }
        [JsonIgnore]
        public long? CategoryId { get; init; }
        public DateTime Created { get; init; }
        public string? CategoryName { get; set; }
        public ArticleDetailVM(long Id, string Title, string Content, long ViewCount, long? CategoryId, DateTime Created)
        {
            this.Id = Id;
            this.Title = Title;
            this.Content = Content;
            this.ViewCount = ViewCount;
            this.CategoryId = CategoryId;
            this.Created = Created;
        }
    }
}
