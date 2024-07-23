using Posig.Blog.Data.Entities;
using Posig.Blog.Shared;

namespace Posig.Blog.Data.Repositories
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        Task<PagedList<BlogPost>> GetPagedBlogPosts(int pageNumber, int pageSize);
    }
}
