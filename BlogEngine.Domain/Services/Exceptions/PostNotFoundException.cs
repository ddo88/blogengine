namespace BlogEngine.Domain.Services.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(int postId) : base($"Post no encontrado {postId}.")
        {

        }
    }
}
