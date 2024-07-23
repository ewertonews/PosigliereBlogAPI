using Posig.Blog.Shared.Entities;

namespace Posig.Blog.Shared.DTOs
{
    public class BlogPostDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; } = new HashSet<CommentDTO>();

        public DateOnly CreatedAt { get; set; }

        public static BlogPostDTO FromBlogPost(BlogPost blogPost)
        {
            return new BlogPostDTO
            {
                Id = blogPost.Id,
                Content = blogPost.Content,
                Title = blogPost.Title,
                CreatedAt = DateOnly.FromDateTime(blogPost.CreatedAt),
                Comments = blogPost.Comments.Select(bpc => new CommentDTO
                {
                    Id = bpc.Id,
                    Author = bpc.Author,
                    CommentText = bpc.CommentText,
                }).ToHashSet(),
            };
        }
    }
}
