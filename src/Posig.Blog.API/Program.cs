using Posig.Blog.API.Middlewares;
using Posig.Blog.Data.Extensions;
using Posig.Blog.Logging;
using Posig.Blog.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning();
builder.Services.AddBlogContext();
builder.Services.AddRepositories();
builder.Services.AddScoped<IBlogPostsService, BlogPostsService>();

builder.Logging.ClearProviders();
builder.AddLogging();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
