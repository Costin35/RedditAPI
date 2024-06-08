using RedditAPI.Data.Entities;
using RedditAPI.Services.Features.Likes;

namespace RedditAPI.Services.Mappers;

public static class LikeMapper
{
    public static LikeDto ToDto(this Like entity)
    {
        return new LikeDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            CommentId = entity.CommentId,
            PostId = entity.PostId
        };
    }
    public static Like ToEntity(this LikeDto dto)
    {
        return new Like
        {
            Id = dto.Id,
            UserId = dto.UserId,
            CommentId = dto.CommentId,
            PostId = dto.PostId
        };
    }
}