using BlogEngine.API.DbContexts;
using BlogEngine.API.Entities;
using BlogEngine.API.Services;
using BlogEngine.Core;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                    ServiceLifetime.Scoped);

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
}
