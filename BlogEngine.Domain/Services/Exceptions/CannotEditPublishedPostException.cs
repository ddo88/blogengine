namespace BlogEngine.Domain.Services.Exceptions
{
    public class CannotEditPublishedPostException : Exception
    {

        public CannotEditPublishedPostException(int postId) : base($"No se puede editar un Post publicado {postId}.")
        {

        }
    }
}
