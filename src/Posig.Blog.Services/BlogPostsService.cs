using Microsoft.EntityFrameworkCore;
using Posig.Blog.Data.Repositories;
using Posig.Blog.Shared;
using Posig.Blog.Shared.DTOs;

namespace Posig.Blog.Services
{
    public class BlogPostsService
    {
        private readonly IRepositoryManager _repositoryManger;


        public BlogPostsService(IRepositoryManager repositoryManger)
        {
            _repositoryManger = repositoryManger;
        }

        public async Task<BlogPostDTO?> GetPostById(Guid blogPostId)
        {
            var blogPost = await _repositoryManger.BlogPosts
                .FindByCondition(bp => bp.Id == blogPostId)
                .Include(bp => bp.Comments)
                .FirstOrDefaultAsync();

            if (blogPost is null)
            {
                return null;
            }
            return BlogPostDTO.FromBlogPost(blogPost);
        }

        public async Task<PagedRecords<ListBlogPostDTO>> GetBlogPosts(int pageNumber, int pageSize, string? searchTerm)
        {
            try
            {
                return await _repositoryManger.BlogPosts.GetPagedBlogPosts(pageNumber, pageSize, searchTerm);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BlogPostDTO> CreateBlogPost(CreateBlogPostDto newBlogPost)
        {
            var blogPost = newBlogPost.ToBlogPost();

            await _repositoryManger.BlogPosts.AddAsync(blogPost);
            await _repositoryManger.SaveAsync();

            return BlogPostDTO.FromBlogPost(blogPost);            
        }

        public async Task<BlogPostCommentDto?> AddCommentToBlogPost(CreateBlogPostCommentDto blogPostComment)
        {
            var blogPost = await _repositoryManger.BlogPosts.GetByIdAsync(blogPostComment.BlogPostId);
            if (blogPost is null)
            {
                return null;
            }
            var comment = blogPostComment.ToComment();
            blogPost.Comments.Add(comment);
            await _repositoryManger.SaveAsync();

            return BlogPostCommentDto.FromComment(comment, blogPost.Id);           
            
        }
    }
}
