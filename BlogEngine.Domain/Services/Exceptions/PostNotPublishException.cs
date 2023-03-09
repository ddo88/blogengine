namespace BlogEngine.Domain.Services.Exceptions
{
    public class PostNotPublishException : Exception
    {

        public PostNotPublishException(int postId) : base($"Post no publicado {postId}.")
        {

        }
    }
}
