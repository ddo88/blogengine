using BlogEngine.API;
using BlogEngine.API.DbContexts;
using BlogEngine.API.Entities;
using BlogEngine.API.Services;
using BlogEngine.Core;
using BlogEngine.Domain.Models;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

namespace BlogEngine.Test
{
    public class DbFixture
    {
        private BlogEngineContext _dbContext;

        public DbFixture()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection
                .AddDbContext<BlogEngineContext>(options =>
                    options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()),
                    ServiceLifetime.Transient);

            serviceCollection.AddIdentity<User, Role>()
                          .AddEntityFrameworkStores<BlogEngineContext>()
                          .AddDefaultTokenProviders();

            serviceCollection.AddScoped<UserManager<User>>();
            serviceCollection.AddScoped<RoleManager<Role>>();

            var t = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name.StartsWith("BlogEngine")).ToList();
            serviceCollection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            serviceCollection.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name.StartsWith("BlogEngine")).ToList());
            serviceCollection.AddTransient<IPostService, PostService>();
            serviceCollection.AddTransient<ICommentService, CommentService>();
            serviceCollection.AddTransient<IPublishService, PublishService>();

            //serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddTransient<IUserSession, MockUserSession>();

            ServiceProvider = serviceCollection.BuildServiceProvider();

        }

        public ServiceProvider ServiceProvider { get; private set; }
    }

    public class BaseTest : IClassFixture<DbFixture>
    {
        public ServiceProvider _serviceProvider;
        public BaseTest(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;

            var db = _serviceProvider.GetService<BlogEngineContext>();
            db.Database.EnsureCreated();
        }
    }

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

    
    public class PostService_should : DbFixture
    {

    }

    public class PublishService_should : DbFixture
    {

    }


    public class MockUserSession : IUserSession
    {
        public int? UserId => 2;
    }
}
