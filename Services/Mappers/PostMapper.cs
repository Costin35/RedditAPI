using RedditAPI.Data.Entities;
using RedditAPI.Services.Features.Posts;

namespace RedditAPI.Services.Mappers;

public static class PostMapper
{
    public static PostDto ToDto(this Post entity)
    {
        return new PostDto
        {
            Id = entity.Id,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
            CreatedAt = entity.CreatedAt,
            UserId = entity.UserId,
            Comments = entity.Comments.Select(c => c.ToDto()).ToList(),
            Likes = entity.Likes.Select(l => l.ToDto()).ToList()
        };
    }
    public static Post ToEntity(this PostDto dto)
    {
        return new Post
        {
            Id = dto.Id,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            CreatedAt = dto.CreatedAt,
            UserId = dto.UserId,
            Comments = dto.Comments.Select(c => c.ToEntity()).ToList(),
            Likes = dto.Likes.Select(l => l.ToEntity()).ToList()
        };
    }
}