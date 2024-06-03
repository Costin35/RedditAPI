namespace RedditAPI.Services.Constants;

public enum ErrorCodes 
{
    UserNotExisting = 1000,
    UserWrongPassword = 1001,
    UserAlreadyExists = 1002,
    UserEmailAlreadyExists = 1003,
    
    PostNotLoggedIn = 2000,
    
    CommentNotLoggedIn = 3000,
    
    LikeNotLoggedIn = 4000,
}