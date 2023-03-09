using BlogEngine.API.Models;

namespace BlogEngine.API.Services
{
    public interface ICommentService
    {
        Task AddCommentAsync(int postId, CreateCommentDto input);
        Task<IEnumerable<CommentDto>> GetAllAsync(int postId);
    }
}