using RedditAPI.Data.Entities;
using RedditAPI.Services.Features.Comments;

namespace RedditAPI.Services.Mappers;

public static class CommentMapper
{
    public static CommentDto ToDto(this Comment entity)
    {
        return new CommentDto
        {
            Id = entity.Id,
            Content = entity.Content,
            CreatedAt = entity.CreatedAt,
            UserId = entity.UserId,
            PostId = entity.PostId,
            Post = entity.Post.ToDto(),
            User = entity.User.ToDto(),
            Likes = entity.Likes.Select(l => l.ToDto()).ToList() 
        };
    }
    
    public static Comment ToEntity(this CommentDto dto)
    {
        return new Comment
        {
            Id = dto.Id,
            Content = dto.Content,
            CreatedAt = dto.CreatedAt,
            UserId = dto.UserId,
            PostId = dto.PostId,
            Post = dto.Post.ToEntity(),
            User = dto.User.ToEntity(),
            Likes = dto.Likes.Select(l => l.ToEntity()).ToList()
        };
    }
}