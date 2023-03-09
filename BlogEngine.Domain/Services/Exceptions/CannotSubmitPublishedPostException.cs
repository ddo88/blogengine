namespace BlogEngine.Domain.Services.Exceptions
{
    public class CannotSubmitPublishedPostException : Exception
    {

        public CannotSubmitPublishedPostException(int postId) : base($"No se puede enviar a aprobación un Post publicado {postId}.")
        {

        }
    }
}
