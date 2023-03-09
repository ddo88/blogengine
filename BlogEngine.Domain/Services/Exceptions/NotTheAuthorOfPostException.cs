namespace BlogEngine.Domain.Services.Exceptions
{
    public class NotTheAuthorOfPostException : Exception
    {
        public NotTheAuthorOfPostException(int postId) : base($"No eres el author del post {postId}.")
        {

        }
    }
}
