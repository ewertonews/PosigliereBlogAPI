using Posig.Blog.Shared.DTOs;
using Posig.Blog.Shared.Entities;

namespace Posig.Blog.Shared
{
    public static class DTOExtensions
    {
        public static BlogPost ToBlogPost(this CreateBlogPostDto dto)
        {
            return new BlogPost
            {
                Author = dto.Author,
                Title = dto.Title,
                Content = dto.Content,
            };
        }

        public static Comment ToComment(this CreateBlogPostCommentDto blogPostCommentDto)
        {
            return new Comment
            {
                Author = blogPostCommentDto.Author,
                CommentText = blogPostCommentDto.CommentText,
                CreatedAt = DateTime.Now,
            };
        }
    }
}
