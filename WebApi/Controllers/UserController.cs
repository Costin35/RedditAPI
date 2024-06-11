using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.Services.Features.Users;
using RedditAPI.WebApi.Models;
using RedditAPI.WebApi.Mappers;
using RegisterRequest = RedditAPI.WebApi.Mappers.RegisterRequest;

namespace RedditAPI.WebApi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public IActionResult GetUserDetails(int? userId)
    {
        var result = _userService.GetDetails(userId);

        return result.Match<IActionResult>(
            onSuccess: userDto => Ok(userDto.ToApiModel()),
            onFailure: error => BadRequest(error.Description)
        );
    }

    [HttpPatch]
    public IActionResult ChangeUserDetails(int? userId, [FromBody] UserDetailsModel userModel)
    {
        var result = _userService.ChangeDetails(userId, userModel.ToDto());

        return result.Match<IActionResult>(
            onSuccess: NoContent,
            onFailure: error => BadRequest(error.Description)
        );
    }

    [HttpDelete]
    public IActionResult DeleteUser(int? userId)
    {
        var result = _userService.DeleteUser(userId);

        return result.Match<IActionResult>(
            onSuccess: NoContent,
            onFailure: error => BadRequest(error.Description)
        );
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] RegisterRequest request)
    {
        var userDto = request.ToDto();
        var result = _userService.CreateUser(userDto);

        return result.Match<IActionResult>(
            onSuccess: Created,
            onFailure: error => BadRequest(error.Description)
        );
    }
}