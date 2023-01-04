using Microsoft.EntityFrameworkCore;
using SunnyBlog.Domain.Entities;

namespace SunnyBlog.Infrastructure
{
    public partial class BlogDbContext : DbContext
    {
        public BlogDbContext()
        {
        }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.HasComment("article table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id");

                entity.Property(e => e.Content)
                    .HasColumnName("content");

                entity.Property(e => e.CreateBy)
                    .HasColumnName("create_by");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("del_flag")
                    .HasDefaultValueSql("'0'")
                    .HasComment("delete flag(0 not deleted，1 deleted)");

                entity.Property(e => e.IsComment)
                    .HasMaxLength(1)
                    .HasColumnName("is_comment")
                    .HasDefaultValueSql("'1'")
                    .IsRequired()
                    .HasComment("Allow comment");

                entity.Property(e => e.IsTop)
                    .HasMaxLength(1)
                    .HasColumnName("is_top")
                    .HasComment("is top");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .IsRequired(true)
                    .HasComment("status (true: published, false: draft)");

                entity.Property(e => e.Summary)
                    .HasMaxLength(1024)
                    .HasColumnName("summary")
                    .HasComment("article summary");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(256)
                    .HasColumnName("thumbnail")
                    .HasComment("缩略图");

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .HasColumnName("title")
                    .HasComment("标题")
                    .IsRequired(true);

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("update_time");

                entity.Property(e => e.ViewCount)
                    .HasColumnName("view_count")
                    .HasDefaultValueSql("'0'")
                    .IsRequired(true);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasComment("article table");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(128)
                    .IsRequired(true);

                entity.Property(e => e.Pid)
                    .HasColumnName("pid");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(512);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
