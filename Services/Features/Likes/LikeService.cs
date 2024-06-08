using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.UnitOfWork;

namespace RedditAPI.Services.Features.Likes;

public class LikeService : ILikeService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public LikeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public int CreateLike(int? userId, int? postId, int? commentId)
    {
        if(!userId.HasValue || (!postId.HasValue && !commentId.HasValue))
        {
            //error bad request
        }
        var user = _unitOfWork.Users.GetById(userId.Value);
        var post = postId.HasValue ? _unitOfWork.Posts.GetById(postId.Value) : null;
        var comment = commentId.HasValue ? _unitOfWork.Comments.GetById(commentId.Value) : null;
        if(user is null || (post is null && comment is null))
        {
            //error not found
        }
        var like = _unitOfWork.Likes.GetByUserAndContent(userId.Value, postId, commentId);
        if (like is not null)
        {
            //error already exists
        }
        var likeToAdd = new Like
        {
            UserId = userId.Value,
            PostId = postId,
            CommentId = commentId
        };
        likeToAdd.Post = post;
        likeToAdd.Comment = comment;
        likeToAdd.User = user;
        user.Likes.Add(likeToAdd);
        if (postId.HasValue && post is null)
        {
            comment.Likes.Add(likeToAdd);
        }
        if(commentId.HasValue && comment is null)
        {
            post.Likes.Add(likeToAdd);
        }
        _unitOfWork.Likes.Add(likeToAdd);
        _unitOfWork.SaveChanges();

        return 200;
    }

    public int DeleteLike(int? likeId, int? userId)
    {
        if(!likeId.HasValue && !userId.HasValue)
        {
            //error bad request
        }
        var like = _unitOfWork.Likes.GetById(likeId.Value);
        if(like is null || like.UserId != userId)
        {
            //error not found
        }
        _unitOfWork.Likes.Delete(like);
        _unitOfWork.SaveChanges();

        return 200;
    }
}