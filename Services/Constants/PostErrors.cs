using RedditAPI.Data.Entities;

namespace RedditAPI.Services.Constants;

public class PostErrors
{
   public static readonly Error NotLoggedIn = new("Post.NotLoggedIn", "You must be logged in to post.");
   
}