using Posig.Blog.Shared;
using Posig.Blog.Shared.DTOs;

namespace Posig.Blog.Services
{
    public interface IBlogPostsService
    {
        Task<BlogPostCommentDto?> AddCommentToBlogPost(Guid blogPostId, CreateBlogPostCommentDto blogPostComment);
        Task<BlogPostDTO> CreateBlogPost(CreateBlogPostDto newBlogPost);
        Task<PagedRecords<ListBlogPostDTO>> GetBlogPosts(int pageNumber, int pageSize, string? searchTerm);
        Task<BlogPostDTO?> GetPostById(Guid blogPostId);
    }
}