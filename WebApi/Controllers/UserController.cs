using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RedditAPI.Services.Features.Users;
using RedditAPI.WebApi.Models;
using RedditAPI.WebApi.Mappers;
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
    public ActionResult<UserModel> GetUserDetails(int? userId)
    {
        if(userId == null)
        {
            return NotFound();
        }
           
        var userDto = _userService.GetDetails(userId);
        if (userDto is null)
        {
            return NotFound();
        }
        return Ok(userDto.ToApiModel());
    }
    [HttpPatch]
    public ActionResult<int> ChangeUserDetails(int? userId, [FromBody] UserDetailsModel userModel)
    {
        var statusCode = _userService.ChangeDetails(userId, userModel.ToDto());
        return StatusCode(statusCode);
    }
    [HttpDelete]
    public ActionResult<int> DeleteUser(int? userId) 
    {
        var statusCode = _userService.DeleteUser(userId);
        return StatusCode(statusCode);
    }
    [HttpPost]
    public ActionResult<int> CreateUser([FromBody] RegisterRequest request)
    {
        var user = request.ToDto();
        var statusCode = _userService.CreateUser(user);
        return StatusCode(statusCode);
    }
}