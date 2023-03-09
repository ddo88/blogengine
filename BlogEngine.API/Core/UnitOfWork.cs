using BlogEngine.API.DbContexts;

namespace BlogEngine.API.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogEngineContext _context;

        public UnitOfWork(BlogEngineContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
