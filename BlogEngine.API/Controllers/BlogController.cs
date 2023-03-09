using BlogEngine.API.Models;
using BlogEngine.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogEngine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Public,Writer,Editor")]
    public class BlogController : ControllerBase
    {
        private readonly IPostService _postService;

        public BlogController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllAsync() => Ok(await _postService.GetAllPublishPostsAsync());

    }
}
