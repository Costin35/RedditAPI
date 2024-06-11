using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.UnitOfWork;
using RedditAPI.Services.Constants;
using RedditAPI.Services.Features.Comments;
using RedditAPI.Services.Mappers;

namespace RedditAPI.Services.Features.Comments;

public class CommentService : ICommentService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public CommentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Result<CommentDto> GetDetails(int? commentId)
    {
        if (!commentId.HasValue)
        {
            Result<CommentDto>.Failure(CommentErrors.NotFound);
        }
        var comment = _unitOfWork.Comments.GetById(commentId.Value);
        if (comment is null)
        {
            Result<CommentDto>.Failure(CommentErrors.NotFound);
        }
        return Result<CommentDto>.Success(comment.ToDto());
    }

    public Result ChangeContent(int? commentId, CreateCommentDto createCommentDto)
    {
        if (!commentId.HasValue)
        {
            return Result.Failure(CommentErrors.NotFound);
        }
        var comment = _unitOfWork.Comments.GetById(commentId.Value);
        if (comment is null)
        {
            return Result.Failure(CommentErrors.NotFound);
        }
        if (!string.IsNullOrWhiteSpace(createCommentDto.Content))
            comment.Content = createCommentDto.Content;
        _unitOfWork.Comments.Update(comment);
        _unitOfWork.SaveChanges();
        
        return Result.Success();
    }

    public Result CreateComment(CreateCommentDto? createCommentDto, int? userId, int? postId)
    {
        if (createCommentDto is null)
        {
            return Result.Failure(CommentErrors.InvalidData);
        }
        if(!postId.HasValue)
        {
            return Result.Failure(CommentErrors.NotFound);
        }
        if (!userId.HasValue)
        {
            return Result.Failure(CommentErrors.NotFound);
        }
        var post = _unitOfWork.Posts.GetById(postId.Value);
        var user = _unitOfWork.Users.GetById(userId.Value);
        var commentToAdd = new Comment
        {
            Content = createCommentDto!.Content, 
            PostId = postId!.Value,
            UserId = userId!.Value,
            CreatedAt = DateTime.UtcNow
        };
        _unitOfWork.Comments.Add(commentToAdd);
        _unitOfWork.SaveChanges();

        return Result.Success();
    }
    
    public Result DeleteComment(int? commentId)
    {
        if (!commentId.HasValue)
        {
            return Result.Failure(CommentErrors.NotFound);
        }
        var comment = _unitOfWork.Comments.GetById(commentId.Value);
        if (comment is null)
        {
            return Result.Failure(CommentErrors.NotFound);
        }
        _unitOfWork.Comments.Delete(comment);
        _unitOfWork.SaveChanges();
        
        return Result.Success();
    }
}