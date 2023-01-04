using System.Text.Json.Serialization;

namespace SunnyBlog.WebAPI.Controllers
{
    public class ArticleListItemVM
    {
        public long Id { get; init; }
        public string Title { get; init; }
        public string? Summary { get; init; }
        public long ViewCount { get; init; }
        [JsonIgnore]
        public long? CategoryId { get; init; }
        public DateTime Created { get; init; }
        public string? CategoryName { get; set; }
        public ArticleListItemVM(long Id, string Title, string? Summary, long ViewCount, long? CategoryId, DateTime Created)
        {
            this.Id = Id;
            this.Title = Title;
            this.Summary = Summary;
            this.ViewCount = ViewCount;
            this.CategoryId = CategoryId;
            this.Created = Created;
        }
        public ArticleListItemVM(long Id, string Title, string? Summary, long ViewCount, long? CategoryId, DateTime Created, string? CategoryName)
        {
            this.Id = Id;
            this.Title = Title;
            this.Summary = Summary;
            this.ViewCount = ViewCount;
            this.CategoryId = CategoryId;
            this.Created = Created;
            this.CategoryName = CategoryName;
        }
    }
}
