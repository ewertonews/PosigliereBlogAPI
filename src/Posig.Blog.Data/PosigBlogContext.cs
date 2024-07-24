using Microsoft.EntityFrameworkCore;
using Posig.Blog.Shared.Entities;

namespace Posig.Blog.Data
{
    public class PosigBlogContext : DbContext
    {
        public PosigBlogContext(DbContextOptions<PosigBlogContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<BlogPost>()
                .HasIndex(b => b.Title)
                .IsUnique();

            //List<Guid> blogPostIds = [Guid.NewGuid(), Guid.NewGuid()];

            var blogPosts = BlogPostsSeedData.GetBlogPosts();
            var comments = BlogPostsSeedData.GetComments();

            modelBuilder.Entity<BlogPost>().HasData(blogPosts);
            modelBuilder.Entity<Comment>().HasData(comments);
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                }

                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
