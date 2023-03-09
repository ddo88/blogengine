using AutoMapper;
using BlogEngine.API.Core;
using BlogEngine.API.Entities;
using BlogEngine.API.Models;
using BlogEngine.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace BlogEngine.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Writer")]
    public class PostController : ControllerBase
    {

        ILogger Logger { get; }

        private readonly IPostService _postService;
        private readonly IBlogSession _session;

        public PostController(ILogger<PostController> logger,IPostService postService,IBlogSession session)
        {
            Logger = logger;
            _postService = postService;
            _session = session;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostFullDto>>> GetAllAsync()
        {
            return Ok(await _postService.GetAllPostsByUserAsync(_session.UserId.Value));
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
