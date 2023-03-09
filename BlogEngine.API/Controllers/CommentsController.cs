using BlogEngine.API.Models;
using BlogEngine.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [ApiController]
    [Route("api/Post/{postId}/[controller]")]
    [Authorize(Roles = "Public,Writer,Editor")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAllAsync(int postId) => Ok(await _commentService.GetAllAsync(postId));

        [HttpPost]
        public async Task<ActionResult> AddCommentAsync(int postId, [FromBody] CreateCommentDto input)
        {
            try {
                await _commentService.AddCommentAsync(postId, input);
                return Ok();
            } 
            catch (PostNotFoundException pnfe) {
                return BadRequest(pnfe.Message);
            }
            catch (PostNotPublishException pnpe) {
                return BadRequest(pnpe.Message);
            }
        }
        
    }


}
