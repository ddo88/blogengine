using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BlogEngine.API.Services
{
    public class PostNotFoundException:Exception {
        public PostNotFoundException(int postId) : base($"Post no encontrado {postId}.")
        {
            
        }
    }

    public class PostStatusNotValidException : Exception
    {
        public PostStatusNotValidException(string status ) : base($"no se puede aprobar/rechazar el Post se encuentra en estado {status}.")
        {

        }
    }

    public class PostNotPublishException : Exception {

        public PostNotPublishException(int postId) : base($"Post no publicado {postId}.")
        {

        }
    }

    public class CannotEditPublishedPostException : Exception
    {

        public CannotEditPublishedPostException(int postId) : base($"No se puede editar un Post publicado {postId}.")
        {

        }
    }

    public class CannotSubmitPublishedPostException : Exception
    {

        public CannotSubmitPublishedPostException(int postId) : base($"No se puede enviar a aprobación un Post publicado {postId}.")
        {

        }
    }

    public class CannotEditSubmittedPostException : Exception
    {

        public CannotEditSubmittedPostException(int postId) : base($"No se puede enviar a aprobación un Post publicado {postId}.")
        {

        }
    }

    public class NotTheAuthorOfPostException : Exception {
        public NotTheAuthorOfPostException(int postId):base($"No eres el author del post {postId}.")
        {
            
        }
    }
}
