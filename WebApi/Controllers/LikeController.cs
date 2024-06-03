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
            var statusCode = _likeService.CreateLike(model.UserId, model.PostId, model.CommentId);
            return StatusCode(statusCode);
        }
        [HttpDelete]
        public IActionResult DeleteLike(int? likeId, int? userId)
        {
            int statusCode = _likeService.DeleteLike(likeId, userId);
            return StatusCode(statusCode);
        }
}