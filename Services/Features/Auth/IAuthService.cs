namespace RedditAPI.Services.Features.Auth;

public interface IAuthService
{
    Result Register(RegisterDto registerDto);
}