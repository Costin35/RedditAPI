namespace RedditAPI.WebApi.Models;

public class CommentModel
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    public int PostId { get; set; }
    public PostModel Post { get; set; }
    public int UserId { get; set; }
    public UserModel User { get; set; }
    public IEnumerable<LikeModel?> Likes { get; set; } = new List<LikeModel>();
}