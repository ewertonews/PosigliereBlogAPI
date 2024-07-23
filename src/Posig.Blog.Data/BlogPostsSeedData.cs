using Posig.Blog.Shared.Entities;

namespace Posig.Blog.Data
{
    public static class BlogPostsSeedData
    {
        public static List<BlogPost> GetBlogPosts(List<Guid> blogPostIds)
        {

            return new List<BlogPost>
            {
                new BlogPost
                {
                    Id = blogPostIds[0],
                    Author = "Author 1",
                    Title = "Blog Post 1",
                    Content = "Content for blog post 1",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new BlogPost
                {
                    Id = blogPostIds[1],
                    Author = "Author 2",
                    Title = "Blog Post 2",
                    Content = "Content for blog post 2",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };
        }

        public static List<Comment> GetComments(List<Guid> blogPostIds)
        {
            return new List<Comment>
            {
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Author = "Commenter 1",
                    CommentText = "This is a comment",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    BlogPostId = blogPostIds[0]
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Author = "Commenter 2",
                    CommentText = "This is another comment",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    BlogPostId = blogPostIds[0]
                },
                new Comment
                {
                    Id = Guid.NewGuid(),
                    Author = "Commenter 3",
                    CommentText = "This is a comment on post 2",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    BlogPostId = blogPostIds[1]
                }
            };
        }
    }

}
