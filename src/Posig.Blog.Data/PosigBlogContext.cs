using Microsoft.EntityFrameworkCore;
using Posig.Blog.Data.Entities;

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
            modelBuilder
                .Entity<BlogPost>()
                .HasIndex(b => b.Title)
                .IsUnique();
        }
    }
}
