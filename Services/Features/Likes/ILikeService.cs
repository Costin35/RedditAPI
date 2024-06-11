namespace RedditAPI.Services.Features.Likes;

public interface ILikeService
{
    public Result CreateLike(int? userId, int? postId, int? commentId);
    public Result DeleteLike(int? likeId, int? userId);
}