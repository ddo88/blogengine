namespace BlogEngine.Domain.Services.Exceptions
{
    public class PostStatusNotValidException : Exception
    {
        public PostStatusNotValidException(string status) : base($"no se puede aprobar/rechazar el Post se encuentra en estado {status}.")
        {

        }
    }
}
