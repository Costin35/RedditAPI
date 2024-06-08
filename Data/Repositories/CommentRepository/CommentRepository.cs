using Microsoft.EntityFrameworkCore;
using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Context;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Repositories.CommentRepository;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    private readonly IAppDbContext _dbContext;
    public void Add(Comment entity)
    {
        _dbContext.Comments.Add(entity);
    }
    public CommentRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Comment? GetById(int id)
    {
        var comment = _dbContext.Comments
            .Include(c=>c.Post)
            .Include(c=>c.User)
            .Include(c=>c.Likes)
            .FirstOrDefault(c => c.Id == id);
        return comment;
    }
}