using Posig.Blog.Data.Entities;

namespace Posig.Blog.Data.Repositories
{
    public class BlogPostRepository : RepositoryBase<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(PosigBlogContext context) : base(context)
        {
        }
    }
}
