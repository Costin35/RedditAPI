using Microsoft.AspNetCore.Mvc;
using RedditAPI.Services.Features.Posts;
using RedditAPI.WebApi.Mappers;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Controllers;

[Route("api/posts")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;
    public PostController(IPostService postService)
    {
        _postService = postService;
    }
    [HttpGet]
    public ActionResult<PostModel> GetPostDetails(int? postId)
    {
        if(postId == null)
        {
            return NotFound();
        }
        var postDto = _postService.GetDetails(postId);
        if(postDto == null)
        {
            return BadRequest();
        }
        return Ok(postDto.ToApiModel());
    }
    [HttpPost]
    public ActionResult<int> CreatePost ([FromBody] PostContentModel model, int? userId)
    {
        var post = model.ToDto();
        var statusCode = _postService.CreatePost(post, userId);
        return StatusCode(statusCode);
    }
    [HttpDelete]
    public ActionResult<int> DeletePost(int? postId) 
    {
        var statusCode = _postService.DeletePost(postId);
        return StatusCode(statusCode);
    }
    [HttpPatch]
    public ActionResult<int> ChangePostContent(int? postId, [FromBody] PostContentModel model)
    {
        var statusCode = _postService.ChangeDetails(postId, model.ToDto());
        return StatusCode(statusCode);
    }
}