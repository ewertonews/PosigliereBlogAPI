using FluentAssertions;
using Microsoft.Extensions.Logging;
using MockQueryable.Moq;
using Moq;
using Posig.Blog.Data.Repositories;
using Posig.Blog.Services;
using Posig.Blog.Shared.DTOs;
using Posig.Blog.Shared;
using Posig.Blog.Shared.Entities;
using System.Linq.Expressions;
using Posig.Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace Posig.Blog.Tests
{
    public class BlogPostsServiceTests
    {
        private readonly Mock<IRepositoryManager> _mockRepositoryManager;
        private readonly Mock<ILogger<BlogPostsService>> _mockLogger;
        private readonly BlogPostsService _blogPostsService;

        public BlogPostsServiceTests()
        {
            _mockRepositoryManager = new Mock<IRepositoryManager>();
            _mockLogger = new Mock<ILogger<BlogPostsService>>();
            _blogPostsService = new BlogPostsService(_mockRepositoryManager.Object, _mockLogger.Object);
        }


        [Fact]
        public async Task GetPostById_ReturnsBlogPostDTO_WhenBlogPostExists()
        {
            var blogPostId = Guid.NewGuid();
            var blogPost = new BlogPost
            {
                Id = blogPostId,
                Author = "Author",
                Title = "Title",
                Content = "Content",
                Comments = new List<Comment>()
            };

            _mockRepositoryManager.Setup(repo => repo.BlogPosts
                .FindByCondition(It.IsAny<Expression<Func<BlogPost, bool>>>()))
                .Returns(new List<BlogPost> { blogPost }.AsQueryable().BuildMock());

            var result = await _blogPostsService.GetPostById(blogPostId);

            result.Should().NotBeNull();
            result!.Id.Should().Be(blogPostId);
            result!.Title.Should().Be(blogPost.Title);            
        }

        [Fact]
        public async Task GetPostById_ReturnsNull_WhenBlogPostDoesNotExist()
        {
            var blogPostId = Guid.NewGuid();

            _mockRepositoryManager.Setup(repo => repo.BlogPosts
                .FindByCondition(It.IsAny<Expression<Func<BlogPost, bool>>>()))
                .Returns(Enumerable.Empty<BlogPost>().AsQueryable().BuildMock());

            var result = await _blogPostsService.GetPostById(blogPostId);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetBlogPosts_ReturnsPagedRecords_WhenCalled()
        {
            int pageNumber = 1;
            int pageSize = 10;

            // Arrange
            var pagedRecords = new PagedRecords<ListBlogPostDto>
            {
                Metadata = new PagedRecordsMetadata
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalCount = 0,
                    TotalPages = 0,
                },
                Items = [],               
            };

            _mockRepositoryManager.Setup(repo => repo.BlogPosts.GetPagedBlogPosts(pageNumber, pageSize, null))
                .ReturnsAsync(pagedRecords);

            var result = await _blogPostsService.GetBlogPosts(pageNumber, pageSize, null);

            result.Should().NotBeNull();
            result.Items.Should().BeEmpty();
        }

        [Fact]
        public async Task GetBlogPosts_ReturnsRecordsMatchingSearch_WhenCalled()
        {
            int pageNumber = 1;
            int pageSize = 10;
            var searchTerm = "Post 1";
            var expectedPostTitle = "Blog Post 1";

            RepositoryManager repositoryManager = GetRepositoryManagerWithInMemoryDb();

            var blogPostService = new BlogPostsService(repositoryManager, _mockLogger.Object);          

            var result = await blogPostService.GetBlogPosts(pageNumber, pageSize, searchTerm);

            result.Should().NotBeNull();
            result.Items.Should().HaveCount(1);
            result.Items[0].Title.Should().Be(expectedPostTitle);
        }

        [Fact]
        public async Task CreateBlogPost_ReturnsBlogPostDTO_WhenSuccessful()
        {
            var newBlogPostDto = new CreateBlogPostDto
            {
                Author = "Author",
                Title = "Title",
                Content = "Content"
            };
            var blogPost = newBlogPostDto.ToBlogPost();

            _mockRepositoryManager.Setup(repo => repo.BlogPosts.AddAsync(It.IsAny<BlogPost>()));
            _mockRepositoryManager.Setup(repo => repo.SaveAsync()).Returns(Task.CompletedTask);

            var result = await _blogPostsService.CreateBlogPost(newBlogPostDto);


            result.Should().NotBeNull();
            result.Title.Should().Be(blogPost.Title);            
        }

        [Fact]
        public async Task AddCommentToBlogPost_ReturnsBlogPostCommentDto_WhenSuccessful()
        {
            var blogPostId = Guid.NewGuid();
            var blogPost = new BlogPost
            {
                Id = blogPostId,
                Author = "Author",
                Title = "Title",
                Content = "Content",
                Comments = new List<Comment>()
            };
            var newCommentDto = new CreateBlogPostCommentDto
            {
                Author = "Commenter",
                CommentText = "This is a comment"
            };
            var comment = newCommentDto.ToComment(blogPost);

            _mockRepositoryManager.Setup(repo => repo.BlogPosts.GetByIdAsync(blogPostId)).ReturnsAsync(blogPost);
            _mockRepositoryManager.Setup(repo => repo.SaveAsync()).Returns(Task.CompletedTask);

            var result = await _blogPostsService.AddCommentToBlogPost(blogPostId, newCommentDto);

            result.Should().NotBeNull();
            result!.CommentText.Should().Be(comment.CommentText);
            result!.BlogPostId.Should().Be(blogPostId);            
        }

        [Fact]
        public async Task AddCommentToBlogPost_ReturnsNull_WhenBlogPostDoesNotExist()
        {
            var blogPostId = Guid.NewGuid();
            var newCommentDto = new CreateBlogPostCommentDto
            {
                Author = "Commenter",
                CommentText = "This is a comment"
            };

            _mockRepositoryManager.Setup(repo => repo.BlogPosts.GetByIdAsync(blogPostId)).ReturnsAsync((BlogPost)null);
            var result = await _blogPostsService.AddCommentToBlogPost(blogPostId, newCommentDto);

            result.Should().BeNull();
        }

        private static RepositoryManager GetRepositoryManagerWithInMemoryDb()
        {
            var blogPosts = BlogPostsSeedData.GetBlogPosts();

            var options = new DbContextOptionsBuilder<PosigBlogContext>()
                .UseInMemoryDatabase(databaseName: "BlogDatabase")
                .Options;

            var context = new PosigBlogContext(options);
            context.BlogPosts.AddRange(blogPosts);
            context.SaveChanges();

            var repositoryManager = new RepositoryManager(context);
            return repositoryManager;
        }
    }
}