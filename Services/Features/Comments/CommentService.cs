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

    public CommentDto GetDetails(int? commentId)
    {
        if (!commentId.HasValue)
        {
            /*CommentErrors.NotFound;
            return null;*/
        }
        var comment = _unitOfWork.Comments.GetById(commentId.Value);
        if (comment is null)
        {
            /*CommentErrors.NotFound;
            return null;*/
        }
        return comment.ToDto();
    }

    public int ChangeContent(int? commentId, CreateCommentDto createCommentDto)
    {
        if (!commentId.HasValue)
        {
            /*
             CommentErrors.NotFound;
             return null;
             */
        }
        var comment = _unitOfWork.Comments.GetById(commentId.Value);
        if (comment is null)
        {
            /*
             CommentErrors.NotFound;
             return null;
            */
        }
        if (!string.IsNullOrWhiteSpace(createCommentDto.Content))
            comment.Content = createCommentDto.Content;
        _unitOfWork.Comments.Update(comment);
        _unitOfWork.SaveChanges();
        
        return 200;
    }

    public int CreateComment(CreateCommentDto createCommentDto, int? userId, int? postId)
    {
        if (createCommentDto is null)
        {
            /*
             *error for null object 
             */
        }
        if(!postId.HasValue)
        {
            /*
             *PostErrors.NotFound;
             */
        }
        if (!userId.HasValue)
        {
            /*
             *UserErrors.NotFound;
             */
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
        commentToAdd.Post = post;
        commentToAdd.User = user;
        user.Comments.Add(commentToAdd);
        post.Comments.Add(commentToAdd);
        _unitOfWork.Comments.Add(commentToAdd);
        _unitOfWork.SaveChanges();
        
        return 200;
    }
    
    public int DeleteComment(int? commentId)
    {
        if (!commentId.HasValue)
        {
            /*
             *CommentErrors.NotFound;
             */
        }
        var comment = _unitOfWork.Comments.GetById(commentId.Value);
        if (comment is null)
        {
            /*
             *CommentErrors.NotFound;
             */
        }
        _unitOfWork.Comments.Delete(comment);
        _unitOfWork.SaveChanges();
        
        return 200;
    }
}