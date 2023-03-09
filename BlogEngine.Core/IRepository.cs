namespace BlogEngine.Core
{
    public interface IRepository
    {
    }

    public interface IRepository<T, U> : IRepository where T : class, IEntity<U>
    {
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetQueryable();
        Task<T?> GetAsync(U Id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T Value);
        Task DeleteAsync(U Id);
    }
}
