using RedditAPI.Services.Features.Users;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Mappers;

public static class UserMapper
{
    public static UserModel ToApiModel(this UserDto userDto)
    {
        return new UserModel
        {
            Id = userDto.Id,
            Username = userDto.Username,
            Email = userDto.Email,
            Password = userDto.Password,
            CreatedAt = userDto.CreatedAt,
            Posts = userDto.Posts.Select(p=>p.ToApiModel()).ToList(),
            Comments = userDto.Comments.Select(c=>c.ToApiModel()).ToList(),
            Likes = userDto.Likes.Select(l=>l.ToApiModel()).ToList()
        };
    }
    public static UserDto ToDto(this UserModel userModel)
    {
        return new UserDto
        {
            Id = userModel.Id,
            Username = userModel.Username,
            Email = userModel.Email,
            Password = userModel.Password,
            CreatedAt = userModel.CreatedAt,
            Posts = userModel.Posts.Select(p=>p.ToDto()).ToList(),
            Comments = userModel.Comments.Select(c=>c.ToDto()).ToList(),
            Likes = userModel.Likes.Select(l=>l.ToDto()).ToList()
        };
    }
}