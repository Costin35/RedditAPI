using RedditAPI.Data.Entities;
using RedditAPI.Services.Features.Users;
using RedditAPI.Services.Features.Posts;
namespace RedditAPI.Services.Mappers;

public static class UserMapper
{
    public static UserDto ToDto(this User entity)
    {
        return new UserDto
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            Password = entity.Password,
            CreatedAt = entity.CreatedAt,
            Posts = entity.Posts.Select(p => p.ToDto()).ToList(),
            Comments = entity.Comments.Select(c => c.ToDto()).ToList(),
            Likes = entity.Likes.Select(l => l.ToDto()).ToList()
        };
    }
    public static User ToEntity(this UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password,
            CreatedAt = dto.CreatedAt,
            Posts = dto.Posts.Select(p => p.ToEntity()).ToList(),
            Comments = dto.Comments.Select(c => c.ToEntity()).ToList(),
            Likes = dto.Likes.Select(l => l.ToEntity()).ToList()
        };
    }
}