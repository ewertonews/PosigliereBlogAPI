using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Posig.Blog.Data.Repositories;
using Posig.Blog.Shared;
using Posig.Blog.Shared.DTOs;

namespace Posig.Blog.Services
{
    public class BlogPostsService : IBlogPostsService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILogger<BlogPostsService> _logger;

        public BlogPostsService(IRepositoryManager repositoryManager, ILogger<BlogPostsService> logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }

        public async Task<BlogPostDTO?> GetPostById(Guid blogPostId)
        {
            try
            {
                var blogPost = await _repositoryManager.BlogPosts
                    .FindByCondition(bp => bp.Id == blogPostId)
                    .Include(bp => bp.Comments)
                    .FirstOrDefaultAsync();

                if (blogPost is null)
                {
                    return null;
                }
                return BlogPostDTO.FromBlogPost(blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching blog post with ID {BlogPostId}", blogPostId);
                throw;
            }
        }

        public async Task<PagedRecords<ListBlogPostDTO>> GetBlogPosts(int pageNumber, int pageSize, string? searchTerm)
        {
            try
            {
                return await _repositoryManager.BlogPosts.GetPagedBlogPosts(pageNumber, pageSize, searchTerm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching blog posts.");
                throw;
            }
        }

        public async Task<BlogPostDTO> CreateBlogPost(CreateBlogPostDto newBlogPost)
        {
            try
            {
                var blogPost = newBlogPost.ToBlogPost();
                await _repositoryManager.BlogPosts.AddAsync(blogPost);
                await _repositoryManager.SaveAsync();
                return BlogPostDTO.FromBlogPost(blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating a new blog post.");
                throw;
            }
        }

        public async Task<BlogPostCommentDto?> AddCommentToBlogPost(Guid blogPostId, CreateBlogPostCommentDto blogPostComment)
        {
            try
            {
                var blogPost = await _repositoryManager.BlogPosts.GetByIdAsync(blogPostId);
                if (blogPost is null)
                {
                    return null;
                }

                var comment = blogPostComment.ToComment(blogPost);
                blogPost.Comments.Add(comment);
                await _repositoryManager.SaveAsync();

                return BlogPostCommentDto.FromComment(comment, blogPost.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding a comment to the blog post with ID {BlogPostId}", blogPostId);
                throw;
            }
        }
    }
}
