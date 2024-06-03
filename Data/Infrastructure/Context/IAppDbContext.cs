using RedditAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using RedditAPI.Data.Infrastructure.Repository;

namespace RedditAPI.Data.Infrastructure.Context;

public interface IAppDbContext : IEntityFrameworkContext
{
    DbSet<User> Users { get; set; }
    DbSet<Post> Posts { get; set; }
    DbSet<Comment> Comments { get; set; }
    DbSet<Like> Likes { get; set; }
}