using Microsoft.AspNetCore.Mvc;
using Posig.Blog.Services;
using Posig.Blog.Shared.DTOs;

namespace Posig.Blog.API.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostsService _blogPostsService;

        public BlogPostsController(IBlogPostsService blogPostsService)
        {
            _blogPostsService = blogPostsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(Guid id)
        {
            var result = await _blogPostsService.GetPostById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogPosts(int pageNumber, int pageSize, string? searchTerm)
        {
            var result = await _blogPostsService.GetBlogPosts(pageNumber, pageSize, searchTerm);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost([FromBody] CreateBlogPostDto newBlogPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _blogPostsService.CreateBlogPost(newBlogPost);
            return CreatedAtAction(nameof(GetPostById), new { id = result.Id }, result);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> AddCommentToBlogPost(Guid id, [FromBody] CreateBlogPostCommentDto blogPostComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _blogPostsService.AddCommentToBlogPost(id, blogPostComment);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
