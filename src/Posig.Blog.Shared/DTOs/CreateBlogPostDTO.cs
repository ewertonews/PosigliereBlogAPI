
namespace Posig.Blog.Shared.DTOs
{
    public class CreateBlogPostDto
    {
        public required string Author { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }        
    }
}
