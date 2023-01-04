namespace SunnyBlog.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? Pid { get; set; }
        public string? Description { get; set; }

    }
}
