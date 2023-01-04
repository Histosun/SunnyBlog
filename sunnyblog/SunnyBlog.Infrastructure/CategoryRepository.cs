using Microsoft.EntityFrameworkCore;
using SunnyBlog.Domain;
using SunnyBlog.Domain.Entities;

namespace SunnyBlog.Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        DbSet<Category> Categories;

        public CategoryRepository(BlogDbContext blogDbContext)
        {
            Categories = blogDbContext.Categories;
        }
        public Category? GetById(long id)
        {
            return Categories.Find(id);
        }

        public Category[] GetCategories()
        {
            throw new NotImplementedException();
        }
    }
}
