using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.UnitOfWork;
using RedditAPI.Services.Constants;

namespace RedditAPI.Services.Features.Likes;

public class LikeService : ILikeService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public LikeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result CreateLike(int? userId, int? postId, int? commentId)
    {
        if(!userId.HasValue || (!postId.HasValue && !commentId.HasValue))
        {
            return Result.Failure(LikeErrors.InvalidData);
        }
        var user = _unitOfWork.Users.GetById(userId.Value);
        var post = postId.HasValue ? _unitOfWork.Posts.GetById(postId.Value) : null;
        var comment = commentId.HasValue ? _unitOfWork.Comments.GetById(commentId.Value) : null;
        if(user is null || (post is null && comment is null))
        {
            return Result.Failure(LikeErrors.NotFound);
        }
        var like = _unitOfWork.Likes.GetByUserAndContent(userId.Value, postId, commentId);
        if (like is not null)
        {
            return Result.Failure(LikeErrors.AlreadyExists);
        }
        var likeToAdd = new Like
        {
            UserId = userId.Value,
            PostId = postId,
            CommentId = commentId
        };
        _unitOfWork.Likes.Add(likeToAdd);
        _unitOfWork.SaveChanges();

        return Result.Success();
    }

    public Result DeleteLike(int? likeId, int? userId)
    {
        if(!likeId.HasValue && !userId.HasValue)
        {
            return Result.Failure(LikeErrors.InvalidData);
        }
        var like = _unitOfWork.Likes.GetById(likeId.Value);
        if(like is null || like.UserId != userId)
        {
            return Result.Failure(LikeErrors.NotFound);
        }
        _unitOfWork.Likes.Delete(like);
        _unitOfWork.SaveChanges();

        return Result.Success();
    }
}