using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.UnitOfWork;
using RedditAPI.Services.Constants;
using RedditAPI.Services.Mappers;

namespace RedditAPI.Services.Features.Posts;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Result CreatePost(PostDetailsDto postDetailsDto, int? userId)
    {
        if (!userId.HasValue)
        {
            return Result.Failure(PostErrors.NotFound);
        }

        if (postDetailsDto is null)
        {
            return Result.Failure(PostErrors.InvalidData);
        }
        var user = _unitOfWork.Users.GetById(userId.Value);
        if (user is null)
        {
            return Result.Failure(PostErrors.NotFound);
        }
        var postToAdd = new Post
        {
            Description = postDetailsDto.Description,
            ImageUrl = postDetailsDto.ImageUrl,
            CreatedAt = DateTime.UtcNow,
            UserId = user.Id
        };
        _unitOfWork.Posts.Add(postToAdd);
        _unitOfWork.SaveChanges();

        return Result.Success();   
    }

    public Result ChangeDetails(int? postId, PostDetailsDto postDetailsDto)
    {
        if(!postId.HasValue)
        {
            return Result.Failure(PostErrors.NotFound);
        }

        if (postDetailsDto is null)
        {
            return Result.Failure(PostErrors.InvalidData);
        }
        var post = _unitOfWork.Posts.GetById(postId.Value);
        if (post is null)
        {
            return Result.Failure(PostErrors.NotFound);
        }
        if (!string.IsNullOrWhiteSpace(postDetailsDto.Description))
        {
            post.Description = postDetailsDto.Description;
        }
        if (!string.IsNullOrWhiteSpace(postDetailsDto.ImageUrl))
        {
            post.ImageUrl = postDetailsDto.ImageUrl;
        }
        _unitOfWork.Posts.Update(post);
        _unitOfWork.SaveChanges();
        
        return Result.Success();
    }

    public Result<PostDto> GetDetails(int? postId)
    {
        if (!postId.HasValue)
        {
            return Result<PostDto>.Failure(PostErrors.InvalidData);
        }
        var post = _unitOfWork.Posts.GetById(postId.Value);
        if (post is null)
        {
            return Result<PostDto>.Failure(PostErrors.NotFound);
        }
        return Result<PostDto>.Success(post.ToDto());
    }
    
    public Result DeletePost(int? postId)
    {
        if (!postId.HasValue)
        {
            return Result.Failure(PostErrors.InvalidData);
        }
        var post = _unitOfWork.Posts.GetById(postId.Value);
        if (post is null)
        {
            return Result.Failure(PostErrors.NotFound);
        }
        _unitOfWork.Posts.Delete(post);
        _unitOfWork.SaveChanges();
        
        return Result.Success();
    }
}