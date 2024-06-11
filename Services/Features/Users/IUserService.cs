using RedditAPI.Services.Features.Auth;

namespace RedditAPI.Services.Features.Users;

public interface IUserService
{
    Result<UserDto> GetDetails(int? userId);
    Result ChangeDetails(int? userId, UserDetailsDto userDto);
    Result DeleteUser(int? userId);
    Result CreateUser(RegisterDto userDto);
}