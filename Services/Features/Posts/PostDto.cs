using RedditAPI.Data.Entities;
using RedditAPI.Services.Features.Comments;
using RedditAPI.Services.Features.Likes;
using RedditAPI.Services.Features.Users;

namespace RedditAPI.Services.Features.Posts;

public class PostDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    public int UserId { get; set; }
    public UserDto User { get; set; }
    public IEnumerable<CommentDto?> Comments { get; set; } = new List<CommentDto>();
    public IEnumerable<LikeDto?> Likes { get; set; } = new List<LikeDto>();
}