using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SunnyBlog.Domain.Entities;

namespace SunnyBlog.Infrastructure.Configs
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("article");

            builder.HasComment("article table");

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(e => e.CategoryId)
                .HasColumnName("category_id");

            builder.Property(e => e.Content)
                .HasColumnName("content");

            builder.Property(e => e.CreateBy)
                .HasColumnName("create_by");

            builder.Property(e => e.CreateTime)
                .HasColumnType("datetime")
                .HasColumnName("create_time");

            builder.Property(e => e.DelFlag)
                .HasColumnName("del_flag")
                .HasDefaultValueSql("'0'")
                .HasComment("delete flag(0 not deleted，1 deleted)");

            builder.Property(e => e.IsComment)
                .HasMaxLength(1)
                .HasColumnName("is_comment")
                .HasDefaultValueSql("'1'")
                .IsRequired()
                .HasComment("Allow comment");

            builder.Property(e => e.IsTop)
                .HasMaxLength(1)
                .HasColumnName("is_top")
                .HasComment("is top");

            builder.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status")
                .HasDefaultValueSql("'1'")
                .IsRequired(true)
                .HasComment("status (true: published, false: draft)");

            builder.Property(e => e.Summary)
                .HasMaxLength(1024)
                .HasColumnName("summary")
                .HasComment("article summary");

            builder.Property(e => e.Thumbnail)
                .HasMaxLength(256)
                .HasColumnName("thumbnail")
                .HasComment("缩略图");

            builder.Property(e => e.Title)
                .HasMaxLength(256)
                .HasColumnName("title")
                .HasComment("标题")
                .IsRequired(true);

            builder.Property(e => e.UpdateBy).HasColumnName("update_by");

            builder.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");

            builder.Property(e => e.ViewCount)
                .HasColumnName("view_count")
                .HasDefaultValueSql("'0'")
                .IsRequired(true);
        }
    }
}
