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
        var like = _dbContext.Likes.FirstOrDefault(l => l.Id == id);
        return like;
    }
}