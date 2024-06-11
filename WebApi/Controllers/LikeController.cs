using Microsoft.AspNetCore.Mvc;
using RedditAPI.Services.Features.Likes;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Controllers;

[Route("api/likes")]
[ApiController]

public class LikeController : ControllerBase
{
    private readonly ILikeService _likeService;

    public LikeController(ILikeService likeService)
    {
        _likeService = likeService;
    }

    [HttpPost]
    public IActionResult CreateLike([FromBody] LikeModel model)
    {
        var result = _likeService.CreateLike(model.UserId, model.PostId, model.CommentId);

        return result.Match<IActionResult>(
            onSuccess: Created,
            onFailure: error => BadRequest(error.Description)
        );
    }

    [HttpDelete]
    public IActionResult DeleteLike(int? likeId, int? userId)
    {
        var result = _likeService.DeleteLike(likeId, userId);

        return result.Match<IActionResult>(
            onSuccess: NoContent,
            onFailure: error => BadRequest(error.Description)
        );
    }
}