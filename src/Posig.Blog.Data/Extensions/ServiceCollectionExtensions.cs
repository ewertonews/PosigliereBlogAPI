using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Posig.Blog.Data.Repositories;

namespace Posig.Blog.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBlogContext(this IServiceCollection services)
        {
            services.AddDbContext<PosigBlogContext>(options => options.UseInMemoryDatabase("posig.blogposts"));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
    }
}
