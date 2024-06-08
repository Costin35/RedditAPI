using RedditAPI.Services.Features.Posts;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Mappers;

public static class PostContentMapper
{
    public static PostDetailsDto ToDto(this PostContentModel postContentModel)
    {
        return new PostDetailsDto
        {
            ImageUrl = postContentModel.ImageUrl,
            Description = postContentModel.Description
        };
    }
}