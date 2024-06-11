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
    public IActionResult GetPostDetails(int? postId)
    {
        var result = _postService.GetDetails(postId);

        return result.Match<IActionResult>(
            onSuccess: postDto => Ok(postDto.ToApiModel()),
            onFailure: error => BadRequest(error.Description)
        );
    }

    [HttpPost]
    public IActionResult CreatePost([FromBody] PostContentModel model, int? userId)
    {
        var postDto = model.ToDto();
        var result = _postService.CreatePost(postDto, userId);

        return result.Match<IActionResult>(
            onSuccess: Created,
            onFailure: error => BadRequest(error.Description)
        );
    }

    [HttpDelete]
    public IActionResult DeletePost(int? postId)
    {
        var result = _postService.DeletePost(postId);

        return result.Match<IActionResult>(
            onSuccess: NoContent,
            onFailure: error => BadRequest(error.Description)
        );
    }

    [HttpPatch]
    public IActionResult ChangePostContent(int? postId, [FromBody] PostContentModel model)
    {
        var postDto = model.ToDto();
        var result = _postService.ChangeDetails(postId, postDto);

        return result.Match<IActionResult>(
            onSuccess: NoContent,
            onFailure: error => BadRequest(error.Description)
        );
    }
}