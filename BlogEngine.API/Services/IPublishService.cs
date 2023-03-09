using BlogEngine.API.Controllers;
using BlogEngine.API.Models;

namespace BlogEngine.API.Services
{
    public interface IPublishService
    {
        Task<IEnumerable<PostDto>> GetAllPendingApprovalPostAsync();
        Task ApproveAsync(ApproveDto input);
        Task RejectAsync(RejectDto input);
    }
}
