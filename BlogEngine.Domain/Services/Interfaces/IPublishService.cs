using BlogEngine.Domain.Models;

namespace BlogEngine.Domain.Services.Interfaces
{
    public interface IPublishService
    {
        Task<IEnumerable<PostDto>> GetAllPendingApprovalPostAsync();
        Task ApproveAsync(ApproveDto input);
        Task RejectAsync(RejectDto input);
    }
}
