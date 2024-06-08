using Microsoft.EntityFrameworkCore;
using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Context;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Repositories.PostRepository;

public class PostRepository : Repository<Post>, IPostRepository
{
    private readonly IAppDbContext _dbContext;
    
    public PostRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
    {
        _dbContext = dbContext;
    }

    public Post? GetById(int id)
    {
        var post = _dbContext.Posts
            .Include(p=>p.User)
            .Include(p=>p.Comments)
            .Include(p=>p.Likes)
            .FirstOrDefault(p => p.Id == id);
        return post;
    }
}