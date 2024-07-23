using Posig.Blog.Shared.Entities;

namespace Posig.Blog.Shared.DTOs
{
    public class BlogPostCommentDto
    {
        public Guid Id { get; set; }
        public required Guid BlogPostId { get; set; }
        public required string  Author { get; set; }
        public required string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }

        public static BlogPostCommentDto FromComment(Comment comment, Guid postId)
        {
            return new BlogPostCommentDto {
                Id = comment.Id,
                Author = comment.Author,
                BlogPostId = postId,
                CommentText = comment.CommentText,
                CreatedAt = comment.CreatedAt,
            };
        }
    }
}
