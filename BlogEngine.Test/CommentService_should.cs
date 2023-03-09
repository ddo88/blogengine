using BlogEngine.Domain.Models;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace BlogEngine.Test
{
    public class CommentService_should: BaseTest
    {
        private readonly ICommentService? _sut;

        public CommentService_should(DbFixture fixture):base(fixture) 
        {
            _sut = _serviceProvider.GetService<ICommentService>();
        }

        [Fact]
        public async Task AddCommentAsync()
        {
            //int postId, CreateCommentDto input
            await _sut.AddCommentAsync(1, new CreateCommentDto { Message = "unit test message" });

            //var db = _serviceProvider.GetService<BlogEngineContext>();
            //var lst = db.Comments.ToList();

            var result = await _sut.GetAllAsync(1);
            result.Count().ShouldBe(1);
        }

        [Fact]
        public async Task GetAllAsync()
        {
            var result = await _sut.GetAllAsync(2);

            result.Count().ShouldBe(2);
            var i = 0;
        }
    }
}
