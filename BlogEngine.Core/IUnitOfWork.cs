namespace BlogEngine.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
