namespace RedditAPI.Data.Entities;

public class Post
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    public IEnumerable<Comment?> Comments { get; set; } = new List<Comment>();
    public IEnumerable<Like?> Likes { get; set; } = new List<Like>();
}