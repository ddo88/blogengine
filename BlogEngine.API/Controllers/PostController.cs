using BlogEngine.Domain.Models;
using BlogEngine.Domain.Services.Exceptions;
using BlogEngine.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Writer")]
    public class PostController : ControllerBase
    {

        ILogger Logger { get; }

        private readonly IPostService _postService;
        private readonly IUserSession _userSession;

        public PostController(ILogger<PostController> logger,IPostService postService,IUserSession userSession)
        {
            Logger = logger;
            _postService = postService;
            _userSession = userSession;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostFullDto>>> GetAllAsync()
        {
            return Ok(await _postService.GetAllPostsByUserAsync(_userSession.UserId.Value));
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreateAsync([FromBody] CreatePostDto input)
        {
            return Ok(await _postService.CreateAsync(input));
        }

        [HttpPut]
        public async Task<ActionResult<PostDto>> EditAsync([FromBody] EditPostDto input)
        {
            try
            {
                return Ok(await _postService.UpdateAsync(input));
            }
            catch (PostNotFoundException pnfe)
            {
                return BadRequest(pnfe.Message);
            }
            catch (NotTheAuthorOfPostException ntaope)
            {
                return BadRequest(ntaope.Message);
            }
            catch (CannotEditPublishedPostException ceppe)
            {
                return BadRequest(ceppe.Message);
            }
        }

        [Route("Submit/{postId}")]
        [HttpPost]
        public async Task<ActionResult> SubmitAsync(int postId) {

            try {
                await _postService.SubmitPostAsync(postId);
            }
            catch (PostNotFoundException pnfe)
            {
                return BadRequest(pnfe.Message);
            }
            catch (NotTheAuthorOfPostException ntaope)
            {
                return BadRequest(ntaope.Message);
            }
            catch (CannotSubmitPublishedPostException ceppe)
            {
                return BadRequest(ceppe.Message);
            }
            return Ok();
        }        
    }
}
