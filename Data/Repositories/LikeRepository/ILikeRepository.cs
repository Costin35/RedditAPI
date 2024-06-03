using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Repositories.LikeRepository;

public interface ILikeRepository : IRepository<Like>
{
    public Like? GetById(int id);
}