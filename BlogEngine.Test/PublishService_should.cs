using BlogEngine.API.DbContexts;
using BlogEngine.API.Entities;
using BlogEngine.Domain.Models;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace BlogEngine.Test
{
    public class PublishService_should : BaseTest 
    {
        private readonly IPublishService? _sut;

        public PublishService_should(DbFixture fixture) : base(fixture)
        {
            _sut = _serviceProvider.GetService<IPublishService>();

        }
        [Fact]
        public async Task ApproveAsync()
        {
            //Arrange
            var db = _serviceProvider.GetService<BlogEngineContext>();
            var post = new API.Entities.Post
            {
                IsPublish = false,
                CreatorId = 2,
                Title = "post",
                Content = "post content",
                Status = API.Entities.PostStatus.Submitted
            };

            db.Posts.Add(post);
            await db.SaveChangesAsync();

            //Act
            await _sut.ApproveAsync(new ApproveDto { PostId = post.Id });

            //Assert
            var entity = db.Posts.FirstOrDefault(x => x.Id == post.Id);
            entity.Status.ShouldBe(PostStatus.Publish);
            entity.IsPublish.ShouldBe(true);
        }

        [Fact]
        public async Task GetAllPendingApprovalPostAsync()
        {
            
            //Arrange
            var db = _serviceProvider.GetService<BlogEngineContext>();
            db.Posts.Add(new API.Entities.Post
            {
                Status = API.Entities.PostStatus.Submitted,
                IsPublish = false,
                CreatorId = 2,
                Title = "post",
                Content = "post content"
            });
            db.Posts.Add(new API.Entities.Post
            {
                Status = API.Entities.PostStatus.Created,
                IsPublish = true,
                CreatorId = 2,
                Title = "post published",
                Content = "post  published content"
            });
            await db.SaveChangesAsync();

            //Act
            var result = await _sut.GetAllPendingApprovalPostAsync();

            //Assert
            result.Count().ShouldBe(1);
        }

        [Fact]
        public async Task RejectAsync()
        {
            //Arrange
            var db = _serviceProvider.GetService<BlogEngineContext>();
            var p = new API.Entities.Post
            {
                Status = API.Entities.PostStatus.Submitted,
                IsPublish = false,
                CreatorId = 2,
                Title = "post",
                Content = "post content"
            };
            db.Posts.Add(p);
            await db.SaveChangesAsync();

            //Act
            await _sut.RejectAsync(new RejectDto { PostId = p.Id });

            //Assert
            var entity = db.Posts.FirstOrDefault(x => x.Id == p.Id);
            entity.Status.ShouldBe(PostStatus.Created);
            entity.IsPublish.ShouldBe(false);
        }
    }
}
