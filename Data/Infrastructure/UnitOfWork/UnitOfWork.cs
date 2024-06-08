using Microsoft.EntityFrameworkCore;
using RedditAPI.Data.Infrastructure.Context;
using RedditAPI.Data.Infrastructure.UnitOfWork;
using RedditAPI.Data.Repositories.CommentRepository;
using RedditAPI.Data.Repositories.LikeRepository;
using RedditAPI.Data.Repositories.PostRepository;
using RedditAPI.Data.Repositories.UserRepository;

namespace RedditAPI.Data.Infrastructure.UnitOfWork;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppDbContext _dbContext;
        
        public UnitOfWork(
            IAppDbContext dbContext,
            IUserRepository userRepository,
            IPostRepository postRepository,
            ICommentRepository commentRepository,
            ILikeRepository likeRepository)
        {
            this._dbContext = dbContext;
            this.Users = userRepository;
            this.Posts = postRepository;
            this.Comments = commentRepository;
            this.Likes = likeRepository;
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Reload<T>(T entity) where T : class
        {
            _dbContext.Entry(entity).Reload();
        }

        public bool IsModified<T>(T entity) where T : class
        {
            return _dbContext.Entry(entity).State == EntityState.Modified;
        }
        public IUserRepository Users { get; private set; }
        public IPostRepository Posts { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public ILikeRepository Likes { get; private set;}
}