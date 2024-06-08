using RedditAPI.Services.Features.Posts;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Mappers;

public static class PostMapper
{
    public static PostDto ToDto(this PostModel postModel)
    {
        return new PostDto
        {
            Id = postModel.Id,
            ImageUrl = postModel.ImageUrl,
            Description = postModel.Description,
            CreatedAt = postModel.CreatedAt,
            UserId = postModel.UserId,
            Comments = postModel.Comments.Select(c=>c.ToDto()).ToList(),
            Likes = postModel.Likes.Select(l=>l.ToDto()).ToList()
        };
    }
    public static PostModel ToApiModel(this PostDto postDto)
    {
        return new PostModel
        {
            Id = postDto.Id,
            ImageUrl = postDto.ImageUrl,
            Description = postDto.Description,
            CreatedAt = postDto.CreatedAt,
            UserId = postDto.UserId,
            Comments = postDto.Comments.Select(c=>c.ToApiModel()).ToList(),
            Likes = postDto.Likes.Select(l=>l.ToApiModel()).ToList()
        };
    }
}