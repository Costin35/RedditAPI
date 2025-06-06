using Microsoft.EntityFrameworkCore;
using RedditAPI.Data.Infrastructure.Context;

namespace RedditAPI.Data.Infrastructure.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext DbContext;

    public Repository(AppDbContext context)
    {
        DbContext = context;
    }

    public IEnumerable<T> GetAll()
    {
        return DbContext.Set<T>().ToList();
    }

    public T Find(int id)
    {
        return DbContext.Set<T>().Find(id)!;
    }

    public void Update(T entity)
    {
        DbContext.Set<T>().Attach(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        DbContext.Set<T>().Remove(entity);
    }

    public void Add(T entity)
    {
        DbContext.Set<T>().Add(entity);
    }
}