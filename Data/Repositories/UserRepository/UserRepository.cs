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
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
        return user;
    }
}
