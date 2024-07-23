namespace Posig.Blog.Data.Entities
{
    public class BlogPost : BaseEntity
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
