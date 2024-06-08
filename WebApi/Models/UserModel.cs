namespace RedditAPI.WebApi.Models;

public class UserModel
{
    public int Id { get; set; } 
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public IEnumerable<CommentModel> Comments { get; set; } = new List<CommentModel>();
    public IEnumerable<PostModel> Posts { get; set; } = new List<PostModel>();
    public IEnumerable<LikeModel> Likes { get; set; } = new List<LikeModel>();
}