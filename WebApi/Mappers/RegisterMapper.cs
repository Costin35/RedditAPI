using Microsoft.AspNetCore.Identity.Data;
using RedditAPI.Services.Features.Auth;

namespace RedditAPI.WebApi.Mappers;

public static class RegisterMapper
{
    public static RegisterDto ToDto(this RegisterRequest registerModel)
    {
        return new RegisterDto
        {
            Username = registerModel.Username,
            Email = registerModel.Email,
            Password = registerModel.Password
        };
    }
}