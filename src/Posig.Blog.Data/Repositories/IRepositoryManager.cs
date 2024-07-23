namespace Posig.Blog.Data.Repositories
{
    public interface IRepositoryManager
    {
        IBlogPostRepository BlogPosts { get; }
        ICommentRepository Comments { get; }
        Task SaveAsync();
    }
}
