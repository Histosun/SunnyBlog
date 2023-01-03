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

        public DbSet<Article> Articles { get; set; } = null!;

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
                entity.ToTable("sg_article");

                entity.HasComment("文章表");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasComment("所属分类id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasComment("文章内容");

                entity.Property(e => e.CreateBy).HasColumnName("create_by");

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("create_time");

                entity.Property(e => e.DelFlag)
                    .HasColumnName("del_flag")
                    .HasDefaultValueSql("'0'")
                    .HasComment("删除标志（0代表未删除，1代表已删除）");

                entity.Property(e => e.IsComment)
                    .HasMaxLength(1)
                    .HasColumnName("is_comment")
                    .HasDefaultValueSql("'1'")
                    .IsFixedLength()
                    .HasComment("是否允许评论 1是，0否");

                entity.Property(e => e.IsTop)
                    .HasMaxLength(1)
                    .HasColumnName("is_top")
                    .HasDefaultValueSql("'0'")
                    .IsFixedLength()
                    .HasComment("是否置顶（0否，1是）");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status")
                    .HasDefaultValueSql("'1'")
                    .IsFixedLength()
                    .HasComment("状态（0已发布，1草稿）");

                entity.Property(e => e.Summary)
                    .HasMaxLength(1024)
                    .HasColumnName("summary")
                    .HasComment("文章摘要");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(256)
                    .HasColumnName("thumbnail")
                    .HasComment("缩略图");

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .HasColumnName("title")
                    .HasComment("标题");

                entity.Property(e => e.UpdateBy).HasColumnName("update_by");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("update_time");

                entity.Property(e => e.ViewCount)
                    .HasColumnName("view_count")
                    .HasDefaultValueSql("'0'")
                    .HasComment("访问量");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
