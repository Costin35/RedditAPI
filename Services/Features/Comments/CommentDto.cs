using RedditAPI.Services.Features.Likes;
using RedditAPI.Services.Features.Posts;
using RedditAPI.Services.Features.Users;

namespace RedditAPI.Services.Features.Comments;

public class CommentDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    public int PostId { get; set; }
    public PostDto Post { get; set; }
    public int UserId { get; set; }
    public UserDto User { get; set; }
    public IEnumerable<LikeDto?> Likes { get; set; } = new List<LikeDto>();
}