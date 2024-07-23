namespace Posig.Blog.Shared.Entities
{
    public class Comment : BaseEntity
    {
        public required string Author { get; set; }
        public required string CommentText { get; set; }
    }
}
