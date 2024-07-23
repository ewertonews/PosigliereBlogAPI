using Posig.Blog.Shared.Entities;

namespace Posig.Blog.Data.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(PosigBlogContext context) : base(context)
        {
        }
    }
}
