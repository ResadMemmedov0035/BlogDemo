using BlogDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDemo.Infrastructure.Data.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.CommentorName).HasColumnName("CommentorName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Content).HasColumnName("Content").HasMaxLength(500).IsRequired();
            builder.Property(x => x.CreatedOnUtc).HasColumnName("CreatedOnUtc").IsRequired();
            builder.Property(x => x.ModifiedOnUtc).HasColumnName("ModifiedOnUtc").IsRequired(false);
            builder.Property(x => x.BlogId).HasColumnName("BlogId").IsRequired();

            builder.HasOne(x => x.Blog)
                   .WithMany(x => x.Comments)
                   .HasConstraintName("FK_Comments_Blogs");
        }
    }
}
