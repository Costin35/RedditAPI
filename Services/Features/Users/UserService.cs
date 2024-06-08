using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.UnitOfWork;
using RedditAPI.Services.Features.Auth;

namespace RedditAPI.Services.Features.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public int CreateUser(RegisterDto userDto)
    {
        if (userDto is null || string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.Password))
        {
            //error invalid data
        }
        var username = _unitOfWork.Users.GetByUsername(userDto.Username);
        var email = _unitOfWork.Users.GetByEmail(userDto.Email);
        if (username is not null || email is not null)
        {
            //error already exists
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

        return 200;
    }
    
    public int ChangeDetails(int? userId, UserDetailsDto userDetailsDto)
    {
        if (!userId.HasValue)
        {
            //error not found
        }
        
        var user = _unitOfWork.Users.GetById(userId.Value);
        var existingUser = _unitOfWork.Users.GetByUsername(userDetailsDto.Username);
        if (existingUser is not null)
        {
            //error already exists
        }
        if (user is null)
        {
            //error not found
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

        return 200;
    }

    public UserDto GetDetails(int? userId)
    {
        var user = _unitOfWork.Users.GetById(userId.Value);
        if (user is null)
        {
            //error not found
        }
        
        return user.ToDto();
    }
    
    public int DeleteUser(int? userId)
    {
        if (!userId.HasValue)
        {
            //error not found
        }
        var user = _unitOfWork.Users.GetById(userId.Value);
        if (user is null)
        {
            //error not found
        }
        _unitOfWork.Users.Delete(user);
        _unitOfWork.SaveChanges();

        return 200;
    }
}