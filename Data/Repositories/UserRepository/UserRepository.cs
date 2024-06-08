using Microsoft.EntityFrameworkCore;
using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Context;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Repositories.UserRepository;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly IAppDbContext _dbContext;
    
    public UserRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
    {
        _dbContext = dbContext;
    }

    public User? GetById(int id)
    {
        var user = _dbContext.Users
            .Include(u=>u.Comments)
            .Include(u=>u.Posts)
            .Include(p=>p.Likes)
            .FirstOrDefault(u => u.Id == id);
        return user;
    }
    
    public User? GetByUsername(string username)
    {
        var user = _dbContext.Users
            .Include(u=>u.Comments)
            .Include(u=>u.Posts)
            .Include(p=>p.Likes)
            .FirstOrDefault(u => u.Username == username);
        return user;
    }
    
    public User? GetByEmail(string email)
    {
        var user = _dbContext.Users
            .Include(u=>u.Comments)
            .Include(u=>u.Posts)
            .Include(p=>p.Likes)
            .FirstOrDefault(u => u.Email == email);
        return user;
    }
}
