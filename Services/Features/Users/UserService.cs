using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.UnitOfWork;
using RedditAPI.Services.Constants;
using RedditAPI.Services.Features.Auth;
using RedditAPI.Services.Mappers;

namespace RedditAPI.Services.Features.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Result CreateUser(RegisterDto? userDto)
    {
        if (userDto is null || string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.Password))
        {
            return Result.Failure(UserErrors.InvalidData);
        }
        var username = _unitOfWork.Users.GetByUsername(userDto.Username);
        var email = _unitOfWork.Users.GetByEmail(userDto.Email);
        if (username is not null || email is not null)
        {
            return Result.Failure(UserErrors.AlreadyExists);
        }
        var userToAdd = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            Password = userDto.Password,
            CreatedAt = DateTime.UtcNow
        };
        _unitOfWork.Users.Add(userToAdd);
        _unitOfWork.SaveChanges();

        return Result.Success();
    }
    
    public Result ChangeDetails(int? userId, UserDetailsDto userDetailsDto)
    {
        if (!userId.HasValue)
        {
            return Result.Failure(UserErrors.NotFound);
        }
        
        var user = _unitOfWork.Users.GetById(userId.Value);
        var existingUser = _unitOfWork.Users.GetByUsername(userDetailsDto.Username);
        if (existingUser is not null)
        {
            return Result.Failure(UserErrors.AlreadyExists);
        }
        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }
        if (!string.IsNullOrWhiteSpace(userDetailsDto.Username))
        {
            user.Username = userDetailsDto.Username;
        }
        if (!string.IsNullOrWhiteSpace(userDetailsDto.Email))
        {
            user.Email = userDetailsDto.Email;
        }
        _unitOfWork.Users.Update(user);
        _unitOfWork.SaveChanges();

        return Result.Success();
    }

    public Result<UserDto> GetDetails(int? userId)
    {
        var user = _unitOfWork.Users.GetById(userId.Value);
        if (user is null)
        {
            return Result<UserDto>.Failure(UserErrors.NotFound);
        }
        
        return Result<UserDto>.Success(user.ToDto());
    }
    
    public Result DeleteUser(int? userId)
    {
        if (!userId.HasValue)
        {
            return Result.Failure(UserErrors.NotFound);
        }
        var user = _unitOfWork.Users.GetById(userId.Value);
        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound);
        }
        _unitOfWork.Users.Delete(user);
        _unitOfWork.SaveChanges();

        return Result.Success();
    }
}