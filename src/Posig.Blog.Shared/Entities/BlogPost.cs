namespace Posig.Blog.Shared.Entities
{
    public class BlogPost : BaseEntity
    {
        public required string Author { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();        
    }
}
