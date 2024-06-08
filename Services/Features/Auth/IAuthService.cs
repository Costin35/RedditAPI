namespace RedditAPI.Services.Features.Auth;

public interface IAuthService
{
    void Register(RegisterDto registerDto);
}