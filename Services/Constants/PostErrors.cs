using System.Runtime.InteropServices.JavaScript;
using RedditAPI.Data.Entities;

namespace RedditAPI.Services.Constants;

public class PostErrors
{
   public static readonly Error NotLoggedIn = new("Post.NotLoggedIn", "You must be logged in to post.");
   public static readonly Error NotFound = new("Post.NotFound", "Post not found.");
   public static readonly Error InvalidData = new("Post.InvalidData", "Invalid data for creating a post.");
}