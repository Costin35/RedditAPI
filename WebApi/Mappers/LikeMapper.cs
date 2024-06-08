using RedditAPI.Services.Features.Likes;
using RedditAPI.WebApi.Models;

namespace RedditAPI.WebApi.Mappers;

public static class LikeMapper
{
    public static LikeModel ToApiModel(this LikeDto likeDto)
    {
        return new LikeModel
        {
            Id = likeDto.Id,
            UserId = likeDto.UserId,
            PostId = likeDto.PostId,
            CommentId = likeDto.CommentId
        };
    }
    public static LikeDto ToDto(this LikeModel likeModel)
    {
        return new LikeDto
        {
            Id = likeModel.Id,
            UserId = likeModel.UserId,
            PostId = likeModel.PostId,
            CommentId = likeModel.CommentId
        };
    }
}