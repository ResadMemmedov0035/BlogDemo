using BlogDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogDemo.Infrastructure.Data.Configurations
{
    internal class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Title).HasColumnName("Title").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Content).HasColumnName("Content").IsRequired();
            builder.Property(x => x.ThumbnailImage).HasColumnName("ThumbnailImage").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Image).HasColumnName("Image").HasMaxLength(100).IsRequired();
            builder.Property(x => x.CreatedOnUtc).HasColumnName("CreatedOnUtc").IsRequired();
            builder.Property(x => x.ModifiedOnUtc).HasColumnName("ModifiedOnUtc").IsRequired(false);
            builder.Property(x => x.CategoryId).HasColumnName("CategoryId").IsRequired();

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Blogs)
                   .HasConstraintName("FK_Blogs_Categories");
        }
    }
}
