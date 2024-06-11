using Microsoft.AspNetCore.Mvc;
using RedditAPI.Services;
using RedditAPI.Services.Constants;
using RedditAPI.Services.Features.Comments;
using RedditAPI.WebApi.Models;
using RedditAPI.WebApi.Mappers;

namespace RedditAPI.WebApi.Controllers;

[Route("/api/comments")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    [HttpGet]
    public IActionResult GetCommentDetails(int? commentId)
    {
        var result = _commentService.GetDetails(commentId);
        return result.Match<IActionResult>(
            onSuccess: commentDto => Ok(commentDto.ToApiModel()),
            onFailure: error => BadRequest(error.Description)
        );
    }

    [HttpPost]
    public IActionResult CreateComment(CreateCommentModel model, int? userId, int? postId)
    {
        var comment = model.ToDto();
        var result = _commentService.CreateComment(comment, userId, postId);
        return result.Match<IActionResult>(
            onSuccess: Created,
            onFailure: error => BadRequest(error.Description)
            );
    }
    
    [HttpDelete]
    public IActionResult DeleteComment(int? commentId)
    {
        var result = _commentService.DeleteComment(commentId);
        return result.Match<IActionResult>(
            onSuccess: NoContent,
            onFailure: error => BadRequest(error.Description)
            );
    }

    [HttpPatch]
    public IActionResult ChangeComment(int? commentId, CreateCommentModel model)
    {
        var comment = model.ToDto();
        var result = _commentService.ChangeContent(commentId, comment);
        return result.Match<IActionResult>(
            onSuccess: NoContent,
            onFailure: error => BadRequest(error.Description)
            );
    }
}