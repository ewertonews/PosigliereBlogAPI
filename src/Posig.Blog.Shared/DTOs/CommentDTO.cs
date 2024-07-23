namespace Posig.Blog.Shared.DTOs
{
    public class CommentDTO
    {
        public Guid Id { get; set; }
        public required string CommentedByName { get; set; }
        public required string CommentText { get; set; }
    }
}