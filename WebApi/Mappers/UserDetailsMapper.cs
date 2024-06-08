using RedditAPI.Services.Features.Users;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Mappers;

public static class UserDetailsMapper
{
    public static UserDetailsModel ToApiModel(this UserDetailsDto userDetailsDto)
    {
        return new UserDetailsModel
        {
            Username = userDetailsDto.Username,
            Email = userDetailsDto.Email
        };
    }
    public static UserDetailsDto ToDto(this UserDetailsModel userDetailsModel)
    {
        return new UserDetailsDto
        {
            Username = userDetailsModel.Username,
            Email = userDetailsModel.Email
        };
    }
}