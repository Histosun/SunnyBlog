using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SunnyBlog.Domain.Entities;

namespace SunnyBlog.Infrastructure.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.HasComment("article table");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(128)
                .IsRequired(true);

            builder.Property(e => e.Pid)
                .HasColumnName("pid");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(512);
        }
    }
}
