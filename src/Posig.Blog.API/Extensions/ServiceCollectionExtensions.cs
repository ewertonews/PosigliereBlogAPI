using Asp.Versioning;

namespace Posig.Blog.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureVersioning(this IServiceCollection services) {

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
