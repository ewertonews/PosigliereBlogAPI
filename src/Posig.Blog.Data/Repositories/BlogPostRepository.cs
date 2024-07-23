using Microsoft.EntityFrameworkCore;
using Posig.Blog.Data.Entities;
using Posig.Blog.Data.Extensions;
using Posig.Blog.Shared;

namespace Posig.Blog.Data.Repositories
{
    public class BlogPostRepository : RepositoryBase<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(PosigBlogContext context) : base(context)
        {            
        }

        public async Task<PagedList<BlogPost>> GetPagedBlogPosts(int pageNumber, int pageSize)
        {
            var blogPosts = await GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return blogPosts.ToPagedList(pageNumber, pageSize);
        }
    }
}
