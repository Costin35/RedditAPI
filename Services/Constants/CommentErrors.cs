namespace RedditAPI.Services.Constants;

    public class CommentErrors
    {
        public static readonly Error NotLoggedIn = new("Comment.NotLoggedIn", "You must be logged in to comment.");
        public static readonly Error NotFound = new("Comment.NotFound", "Comment not found.");
        public static readonly Error InvalidData = new("Comment.InvalidData", "Invalid data for creating a comment.");
    }