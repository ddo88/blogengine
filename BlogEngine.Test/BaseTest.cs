using BlogEngine.API.DbContexts;
using Microsoft.Extensions.DependencyInjection;

namespace BlogEngine.Test
{
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
}
