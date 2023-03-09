namespace BlogEngine.Domain.Services.Exceptions
{
    public class CannotEditSubmittedPostException : Exception
    {

        public CannotEditSubmittedPostException(int postId) : base($"No se puede enviar a aprobación un Post publicado {postId}.")
        {

        }
    }
}
