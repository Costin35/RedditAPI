namespace RedditAPI.Services.Constants;

public class UserErrors
{
    public static readonly Error NotExistingUser = new Error("User.NotExisting","User does not exist.");
    public static readonly Error WrongPassword = new Error("User.WrongPassword","Wrong password.");
    public static readonly Error UserAlreadyExists = new Error("User.AlreadyExists","User already exists.");
    public static readonly Error EmailAlreadyExists = new Error("User.EmailAlreadyExists","Email already used.");
    public static readonly Error InvalidRegisterData = new Error("User.InvalidRegisterData","Invalid data.");
    public static readonly Error InvalidData = new Error("User.InvalidData","Invalid data.");
    public static readonly Error AlreadyExists = new Error("User.AlreadyExists","User already exists.");
    public static readonly Error NotFound = new Error("User.NotFound","User not found.");
}