namespace RedditAPI.Services.Features.Comments;

public interface ICommentService
{
    Result<CommentDto> GetDetails(int? commentId);
    Result ChangeContent(int? commentId, CreateCommentDto createCommentDto);
    Result CreateComment(CreateCommentDto createCommentDto, int? userId, int? postId);
    Result DeleteComment(int? commentId);
}