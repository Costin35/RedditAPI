using RedditAPI.Data.Repositories;
using RedditAPI.Data.Repositories.CommentRepository;
using RedditAPI.Data.Repositories.LikeRepository;
using RedditAPI.Data.Repositories.PostRepository;
using RedditAPI.Data.Repositories.UserRepository;

namespace RedditAPI.Data.Infrastructure.UnitOfWork;

public interface IUnitOfWork
{
    public IUserRepository Users{ get; }
    public IPostRepository Posts  { get; }
    public ICommentRepository Comments { get; }
    public ILikeRepository Likes { get; }
    int SaveChanges();
    void Reload<T>(T entity) where T : class;
    bool IsModified<T>(T entity) where T : class;
    void Dispose();
}