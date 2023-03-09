namespace BlogEngine.API.Core
{
    public interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
