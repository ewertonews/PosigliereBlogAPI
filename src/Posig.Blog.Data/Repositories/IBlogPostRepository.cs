using Posig.Blog.Shared.Entities;
using Posig.Blog.Shared;
using Posig.Blog.Shared.DTOs;

namespace Posig.Blog.Data.Repositories
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        Task<PagedRecords<ListBlogPostDto>> GetPagedBlogPosts(int pageNumber, int pageSize, string? searchTerm);
    }
}
