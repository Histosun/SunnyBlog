namespace SunnyBlog.Domain.Entities
{
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public string? Summary { get; set; }
        public long? CategoryId { get; set; }
        public string? Thumbnail { get; set; }
        public string? IsTop { get; set; }
        public char? Status { get; set; }
        public long ViewCount { get; set; }
        public string? IsComment { get; set; }
        public long? CreateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public long? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? DelFlag { get; set; }
    }
}
