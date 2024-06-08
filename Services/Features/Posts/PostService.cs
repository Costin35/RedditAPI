using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.UnitOfWork;
using RedditAPI.Services.Mappers;

namespace RedditAPI.Services.Features.Posts;

public class PostService : IPostService
{
    private readonly IUnitOfWork _unitOfWork;
    public PostService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public int CreatePost(PostDetailsDto postDetailsDto, int? userId)
    {
        if (!userId.HasValue)
        {
            //error not found
        }

        if (postDetailsDto is null)
        {
            //error invalid data
        }
        var user = _unitOfWork.Users.GetById(userId.Value);
        if (user is null)
        {
            //error not found
        }
        var postToAdd = new Post
        {
            Description = postDetailsDto.Description,
            ImageUrl = postDetailsDto.ImageUrl,
            CreatedAt = DateTime.UtcNow,
            UserId = user.Id
        };
        user.Posts.Add(postToAdd);
        _unitOfWork.Posts.Add(postToAdd);
        _unitOfWork.SaveChanges();

        return 200;   
    }

    public int ChangeDetails(int? postId, PostDetailsDto postDetailsDto)
    {
        if(!postId.HasValue)
        {
            //error not found
        }

        if (postDetailsDto is null)
        {
            //error invalid data
        }
        var post = _unitOfWork.Posts.GetById(postId.Value);
        if (post is null)
        {
            //error not found
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
        
        return 200;
    }

    public PostDto GetDetails(int? postId)
    {
        if (!postId.HasValue)
        {
            //error invalid data
        }
        var post = _unitOfWork.Posts.GetById(postId.Value);
        if (post is null)
        {
            //error not found
        }
        return post.ToDto();
    }
    
    public int DeletePost(int? postId)
    {
        if (!postId.HasValue)
        {
            //error invalid data
        }
        var post = _unitOfWork.Posts.GetById(postId.Value);
        if (post is null)
        {
            //error not found
        }
        _unitOfWork.Posts.Delete(post);
        _unitOfWork.SaveChanges();
        
        return 200;
    }
}