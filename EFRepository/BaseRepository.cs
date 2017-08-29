using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
  using System.Data.Entity;

  public class BaseRepository<T>:IBaseRepository<T> where T : class
  {
    private readonly DbContext dbContext;
    private readonly IDbSet<T> dbSet;

    protected BaseRepository(DbContext dataDbContext)
    {
      this.dbContext = dataDbContext;
      this.dbSet = dataDbContext.Set<T>();
      this.HasDisposed = false;
    }

    private Boolean HasDisposed { get; set; }

    public IQueryable<T> Entities
    {
      get { return this.dbSet; }
    }

    public T New()
    {
      return this.dbSet.Create();
    }

    public void Update(T entity)
    {
      this.dbSet.Attach(entity);
      this.dbContext.Entry(entity).State = EntityState.Modified;
      this.Save();
    }

    public T Create(T entity)
    {
      T added = null;
      added = this.dbSet.Add(entity);
      this.Save();
      return added;
    }

    public void Create(List<T> collection)
    {
      this.dbContext.Configuration.AutoDetectChangesEnabled = false;
      var count = 0;
      foreach (var entity in collection)
      {
        ++count;
        this.dbSet.Add(entity);
        if (count % 100 == 0 || (collection.Count - count) < 100)
        {
          this.Save();
        }
      }
    }

    public void Delete(T entity)
    {
      this.dbSet.Remove(entity);
      this.Save();
    }

    public void SetAsDeleted(List<T> entityCollection)
    {
      foreach (var entity in entityCollection)
      {
        this.dbSet.Attach(entity);
        this.dbContext.Entry(entity).State = EntityState.Deleted;
      }
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected internal void Save()
    {
      this.dbContext.SaveChanges();
    }

    // Protected implementation of Dispose pattern. 
    protected virtual void Dispose(Boolean disposing)
    {
      if (this.HasDisposed)
      {
        return;
      }
      if (disposing)
      {
        this.dbContext.Dispose();
      }

      this.HasDisposed = true;
    }
  }
}

