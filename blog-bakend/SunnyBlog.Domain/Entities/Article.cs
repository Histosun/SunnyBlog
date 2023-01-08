using SunnyCommons.Domain;

namespace SunnyBlog.Domain.Entities
{
    public class Article : IHasUpdateTime
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public string? Summary { get; set; }
        public long? CategoryId { get; set; }
        public string? Thumbnail { get; set; }
        public byte? IsTop { get; set; }
        public byte Status { get; set; }
        public long ViewCount { get; set; }
        public byte IsComment { get; set; }
        public long? CreateBy { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public long? UpdateBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int DelFlag { get; set; }
    }
}
