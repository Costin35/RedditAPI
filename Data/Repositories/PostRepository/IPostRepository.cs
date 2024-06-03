using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Repositories.PostRepository;

public interface IPostRepository : IRepository<Post>
{
    Post? GetById(int id);
}