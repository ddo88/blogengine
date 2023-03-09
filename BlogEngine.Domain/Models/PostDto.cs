using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Domain.Models
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

    }

    public class PostFullDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string ReasonOfReject { get; set; }
        public DateTime? PublishDate { get; set; }

    }

    public class EditPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }


    public class CreateCommentDto
    {
        public string Message { get; set; }

    }

    public class CommentDto
    {
        public string Message { get; set; }

        public string Author { get; set; }

    }
    public class AuthenticationRequestBody {
        [Required]
        public string UserName { get; set; }

        [Required] 
        public string Password { get; set; }
    }

    public class RejectDto {
        public int PostId { get; set; }
        public string Message { get; set; }

    }
    public class ApproveDto {
        public int PostId { get; set; }
    }
        //public record RejectDto(int PostId, string Message);

    //public record ApproveDto(int PostId);
}
