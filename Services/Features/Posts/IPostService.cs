namespace RedditAPI.Services.Features.Posts;

public interface IPostService
{
    Result CreatePost(PostDetailsDto postDetailsDto, int? userId);
    Result<PostDto> GetDetails(int? postId);
    Result ChangeDetails(int? postId, PostDetailsDto postDetailsDto);
    Result DeletePost(int? postId);
}