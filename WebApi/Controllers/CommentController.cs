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
    public ActionResult<CommentModel> GetCommentDetails(int? commentId)
    {
        if (commentId is null)
        {
            return NotFound();
        }

        var commentDto = _commentService.GetDetails(commentId);
        if (commentDto is null)
        {
            return NotFound();
        }
        return Ok(commentDto.ToModel());
    }

    [HttpPost]
    public ActionResult<int> CreateComment(CreateCommentModel model, int? userId, int? postId)
    {
        var comment = model.ToDto();
        var statusCode = _commentService.CreateComment(comment, userId, postId);
        return StatusCode(statusCode);
    }
    
    [HttpDelete]
    public ActionResult<int> DeleteComment(int? commentId)
    {
        if (commentId is null)
        {
            return NotFound();
        }

        var statusCode = _commentService.DeleteComment(commentId);
        return StatusCode(statusCode);
    }

    [HttpPatch]
    public ActionResult<int> ChangeComment(int? commentId, CreateCommentModel model)
    {
        var comment = model.ToDto();
        var statusCode = _commentService.ChangeComment(commentId, comment);
        return StatusCode(statusCode);
    }
}