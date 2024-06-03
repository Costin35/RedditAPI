namespace RedditAPI.Services.Features.Comments;

public interface ICommentService
{
    CommentDto GetDetails(int? commentId);
    int ChangeContent(int? commentId, CreateCommentDto createCommentDto);
    int CreateComment(CreateCommentDto createCommentDto, int? userId, int? postId);
    int DeleteComment(int? commentId);
}