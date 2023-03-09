namespace BlogEngine.API.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
