using BlogEngine.Domain.Models;

namespace BlogEngine.Domain.Services.Interfaces
{
    public interface ICommentService
    {
        Task AddCommentAsync(int postId, CreateCommentDto input);
        Task<IEnumerable<CommentDto>> GetAllAsync(int postId);
    }
}