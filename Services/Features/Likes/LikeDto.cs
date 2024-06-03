using RedditAPI.Services.Features.Comments;
using RedditAPI.Services.Features.Posts;
using RedditAPI.Services.Features.Users;

namespace RedditAPI.Services.Features.Likes;

public class LikeDto
{
    public int Id{ get; set; }
    public int UserId { get; set; }
    public UserDto User { get; set; }
    public int? PostId { get; set; }
    public PostDto? Post { get; set; }
    public int? CommentId { get; set; }
    public CommentDto? Comment { get; set; }
}