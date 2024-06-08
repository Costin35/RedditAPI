using RedditAPI.Services.Features.Auth;

namespace RedditAPI.Services.Features.Users;

public interface IUserService
{
    UserDto GetDetails(int? userId);
    int ChangeDetails(int? userId, UserDetailsDto userDto);
    int DeleteUser(int? userId);
    int CreateUser(RegisterDto userDto);
}