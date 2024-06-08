using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Repositories.UserRepository;

public interface IUserRepository : IRepository<User>
{
    User? GetById(int id);
    User? GetByUsername(string username);
    User? GetByEmail(string email);
    
}