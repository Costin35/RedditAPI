namespace RedditAPI.Services.Features.Posts;

public interface IPostService
{
    int CreatePost(PostDetailsDto postDetailsDto, int? userId);
    PostDto GetDetails(int? postId);
    int ChangeDetails(int? postId, PostDetailsDto postDetailsDto);
    int DeletePost(int? postId);
}