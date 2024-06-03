namespace RedditAPI.Data.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    
    public IEnumerable<Post?> Posts { get; set; } = new List<Post>();
    public IEnumerable<Comment?> Comments { get; set; } = new List<Comment>();
    public IEnumerable<Like?> Likes { get; set; } = new List<Like>();
}