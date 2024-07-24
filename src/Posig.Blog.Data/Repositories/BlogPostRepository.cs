using Microsoft.EntityFrameworkCore;
using Posig.Blog.Data.Extensions;
using Posig.Blog.Shared;
using Posig.Blog.Shared.DTOs;
using Posig.Blog.Shared.Entities;

namespace Posig.Blog.Data.Repositories
{
    public class BlogPostRepository : RepositoryBase<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(PosigBlogContext context) : base(context)
        {            
        }

        public async Task<PagedRecords<ListBlogPostDto>> GetPagedBlogPosts(int pageNumber, int pageSize, string? searchTerm)
        {
            IQueryable<BlogPost> blogPostsQuery = GetAll();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                blogPostsQuery = blogPostsQuery.Where(b => b.Title.Contains(searchTerm.Trim()));
            }    
            
            List<ListBlogPostDto> blogPosts = await blogPostsQuery
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(bp => bp.Title)
                .Select(bp => ListBlogPostDto.FromBlogPost(bp))
                .ToListAsync();


            PagedRecords<ListBlogPostDto> paged = blogPosts.ToPagedList(pageNumber, pageSize);
            return paged;
        }
    }
}
