namespace RedditAPI.Services.Constants;

public class LikeErrors
{
    public static readonly Error NotLoggedIn = new("Like.NotLoggedIn", "You must be logged in to like a post or a comment.");
}