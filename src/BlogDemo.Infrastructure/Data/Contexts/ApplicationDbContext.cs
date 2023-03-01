using BlogDemo.Domain.Base;
using BlogDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogDemo.Infrastructure.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>()) 
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedOnUtc = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.ModifiedOnUtc = DateTime.UtcNow,
                    _ => null
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
