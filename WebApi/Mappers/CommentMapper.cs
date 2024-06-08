using Microsoft.EntityFrameworkCore;
using RedditAPI.Services.Features.Comments;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Mappers;

public static class CommentMapper
{
    public static CommentModel ToApiModel(this CommentDto commentDto)
    {
        return new CommentModel
        {
            Id = commentDto.Id,
            Content = commentDto.Content,
            PostId = commentDto.PostId,
            UserId = commentDto.UserId,
            CreatedAt = commentDto.CreatedAt,
            Likes = commentDto.Likes.Select(l=>l.ToApiModel()).ToList()
        };
    }
    public static CommentDto ToDto(this CommentModel commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Content = commentModel.Content,
            PostId = commentModel.PostId,
            UserId = commentModel.UserId,
            CreatedAt = commentModel.CreatedAt,
            Likes = commentModel.Likes.Select(l=>l.ToDto()).ToList()
        };
    }
}