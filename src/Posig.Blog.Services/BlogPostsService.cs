using Posig.Blog.Data.Repositories;
using Posig.Blog.Services.DTOs;

namespace Posig.Blog.Services
{
    public class BlogPostsService
    {
        private readonly IRepositoryManager _repositoryManger;

        public BlogPostsService(IRepositoryManager repositoryManger)
        {
            _repositoryManger = repositoryManger;
        }

        public async Task<ListBlogPostDTO> GetBlogPosts()
        {

        }
    }
}
