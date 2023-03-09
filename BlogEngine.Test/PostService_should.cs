using BlogEngine.API.DbContexts;
using BlogEngine.API.Services;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace BlogEngine.Test
{
    public class PostService_should : BaseTest
    {
        private readonly IPostService? _sut;

        public PostService_should(DbFixture fixture) : base(fixture)
        {
            _sut = _serviceProvider.GetService<IPostService>();
        }

        [Fact]
        public async Task CreateAsync()
        {
            var result = await _sut.CreateAsync(new Domain.Models.CreatePostDto { Title = "Unit Test Post", Content = "Unit test content" });
            result.Title.ShouldBe("Unit Test Post");
            result.Content.ShouldBe("Unit test content");
            result.Id.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task GetAllPostsByUserAsync()
        {
            //Arrange
            var db = _serviceProvider.GetService<BlogEngineContext>();
                db.Posts.Add(new API.Entities.Post {
                    IsPublish = false,
                    CreatorId = 2,
                    Title = "post",
                    Content = "post comments" });
            await db.SaveChangesAsync();

            //Act
            var results = await _sut.GetAllPostsByUserAsync(2);

            //Assert
            var p = results.FirstOrDefault();
            p.Title.ShouldBe("post");
            p.Content.ShouldBe("post comments");

        }

        [Fact]
        public async Task GetAllPublishPostsAsync()
        {
            //Arrange
            var db = _serviceProvider.GetService<BlogEngineContext>();
            db.Posts.Add(new API.Entities.Post
            {
                IsPublish = false,
                CreatorId = 2,
                Title = "post",
                Content = "post content"
            });

            db.Posts.Add(new API.Entities.Post
            {
                IsPublish = true,
                CreatorId = 2,
                Title = "post published",
                Content = "post  published content"
            });

            await db.SaveChangesAsync();

            //Act
            var results = await _sut.GetAllPublishPostsAsync();
            

            //Assert
            var p = results.FirstOrDefault(x=>x.Title == "post published");
            p.Title.ShouldBe("post published");
            p.Content.ShouldBe("post  published content");

            p = results.FirstOrDefault(x => x.Title == "post");
            p.ShouldBe(null);

        }

        public Task SubmitPostAsync()
        {
            //int postId
            throw new NotImplementedException();
        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
            //PostDto
            //EditPostDto input
            //throw new NotImplementedException();
        }
    }
}
