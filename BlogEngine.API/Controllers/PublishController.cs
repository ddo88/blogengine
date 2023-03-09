using BlogEngine.API.Models;
using BlogEngine.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Editor")]
    public class PublishController:ControllerBase
    {
        private readonly IPublishService _publishService;

        public PublishController(IPublishService publishService)
        {
            _publishService = publishService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPostAsync()
        {
            IEnumerable<PostDto> lst = await _publishService.GetAllPendingApprovalPostAsync();
            return Ok(lst);
        }

        [HttpPost]
        [Route("Reject")]
        public async Task<ActionResult> RejectAsync([FromBody] RejectDto input) {
            
            await _publishService.RejectAsync(input);
            return Ok();
        }

        [HttpPost]
        [Route("Approve")]
        public async Task<ActionResult> ApproveAsync([FromBody] ApproveDto input)
        {
            await _publishService.ApproveAsync(input);
            return Ok();
        }

    }

    public class RejectDto
    {
        public int PostId { get; set; }
        public string Message { get; set; }

    }

    public class ApproveDto
    {
        public int PostId { get; set; }
    }
    
}
