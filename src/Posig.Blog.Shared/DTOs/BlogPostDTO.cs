namespace Posig.Blog.Shared.DTOs
{
    public class BlogPostDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public IReadOnlyList<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
        public DateOnly CreatedAt { get; set; }
    }
}
