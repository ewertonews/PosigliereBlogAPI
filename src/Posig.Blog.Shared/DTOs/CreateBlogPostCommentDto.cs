namespace Posig.Blog.Shared.DTOs
{
    public class CreateBlogPostCommentDto
    {
        public required Guid BlogPostId { get; set; }
        public required string Author { get; set; }        
        public required string CommentText { get; set; }
    }
}
