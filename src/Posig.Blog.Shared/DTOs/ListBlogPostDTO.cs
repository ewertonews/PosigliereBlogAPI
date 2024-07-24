using Posig.Blog.Shared.Entities;

namespace Posig.Blog.Shared.DTOs
{
    public class ListBlogPostDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required int NumberOfComments { get; set; }

        public static ListBlogPostDto FromBlogPost(BlogPost blogPost)
        {
            return new ListBlogPostDto
            {
                Id = blogPost.Id,
                Title = blogPost.Title,
                NumberOfComments = blogPost.Comments.Count
            };
        }
    }
}
