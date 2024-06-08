using Microsoft.EntityFrameworkCore;
using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Context;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Repositories.LikeRepository;

public class LikeRepository : Repository<Like>, ILikeRepository
{
    private readonly IAppDbContext _dbContext;
    
    public LikeRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Like? GetById(int id)
    {
        var like = _dbContext.Likes
            .Include(l=>l.User)
            .Include(l=>l.Post)
            .Include(l=>l.Comment)
            .FirstOrDefault(l => l.Id == id);
        return like;
    }
    public Like? GetByUserAndContent(int userId, int? postId, int? commentId)
    {
        var like = _dbContext.Likes
            .Include(l=>l.User)
            .Include(l=>l.Post)
            .Include(l=>l.Comment)
            .FirstOrDefault(l => l.UserId == userId && l.PostId == postId && l.CommentId == commentId);
        return like;
    }
}