using SunnyBlog.Domain.Entities;

namespace SunnyBlog.Domain
{
    public interface ICategoryRepository
    {
        public Category GetById(long id);
        public Category[] GetCategories();
    }
}
