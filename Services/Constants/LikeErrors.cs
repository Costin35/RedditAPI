namespace RedditAPI.Services.Constants;

public class LikeErrors
{
    public static readonly Error NotLoggedIn = new("Like.NotLoggedIn", "You must be logged in to like a post or a comment.");
    public static readonly Error NotFound = new("Like.NotFound", "Post or comment not found.");
    public static readonly Error InvalidData = new("Like.InvalidData", "Invalid data for creating a like.");
    public static readonly Error AlreadyExists = new("Like.AlreadyExists", "Like already exists.");
}