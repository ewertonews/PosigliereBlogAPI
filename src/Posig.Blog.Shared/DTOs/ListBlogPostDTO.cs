namespace Posig.Blog.Shared.DTOs
{
    public class ListBlogPostDTO
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required int NumberOfComments { get; set; }
    }
}
