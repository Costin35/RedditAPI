using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Context;
using RedditAPI.Data.Infrastructure.UnitOfWork;
using RedditAPI.Services.Constants;

namespace RedditAPI.Services.Features.Auth;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _dbContext;
    
    public AuthService(IUnitOfWork unitOfWork, AppDbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }
    
    public Result Register(RegisterDto registerDto)
    {
        if (string.IsNullOrWhiteSpace(registerDto.Username) || string.IsNullOrWhiteSpace(registerDto.Email) || string.IsNullOrWhiteSpace(registerDto.Password))
        {
            return Result.Failure(UserErrors.InvalidRegisterData);
        }
        var username = _unitOfWork.Users.GetByUsername(registerDto.Username);
        var email = _unitOfWork.Users.GetByEmail(registerDto.Email);
        if (username is not null || email is not null)
        {
            return Result.Failure(UserErrors.UserAlreadyExists);
        }
        return Result.Success();
    }
}