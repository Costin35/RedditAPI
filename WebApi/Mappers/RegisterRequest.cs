using System.ComponentModel.DataAnnotations;

namespace RedditAPI.WebApi.Mappers;

public class RegisterRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}