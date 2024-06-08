namespace RedditAPI.WebApi.Models;

public class PostModel
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    public int UserId { get; set; }
    public UserModel User { get; set; }
    public IEnumerable<CommentModel?> Comments { get; set; } = new List<CommentModel>();
    public IEnumerable<LikeModel?> Likes { get; set; } = new List<LikeModel>();
}