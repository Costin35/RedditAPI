using RedditAPI.Services.Features.Comments;
using RedditAPI.Services.Features.Likes;
using RedditAPI.Services.Features.Posts;

namespace RedditAPI.Services.Features.Users;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    public IEnumerable<PostDto?> Posts { get; set; } = new List<PostDto>();
    public IEnumerable<CommentDto?> Comments { get; set; } = new List<CommentDto>();
    public IEnumerable<LikeDto?> Likes { get; set; } = new List<LikeDto>();
}
