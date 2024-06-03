using RedditAPI.Data.Entities;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Repositories.CommentRepository;

public interface ICommentRepository : IRepository<Comment>
{
    public Comment? GetById(int id);
}