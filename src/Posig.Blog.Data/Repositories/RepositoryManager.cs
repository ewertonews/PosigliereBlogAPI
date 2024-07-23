namespace Posig.Blog.Data.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly PosigBlogContext _context;
        private IBlogPostRepository? _blogPostRepository;
        private ICommentRepository? _commentRepository;

        public RepositoryManager(PosigBlogContext context)
        {
            _context = context;
        }

        public IBlogPostRepository BlogPosts 
        { 
            get => _blogPostRepository ??= new BlogPostRepository(_context);
        }

        public ICommentRepository Comments
        {
            get => _commentRepository ??= new CommentRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync(); 
        }
    }
}
