using System.Linq;
using System.Data.Entity;

namespace BlogSystem.Data.Repositories
{
    public class DbRepository<TEntity> : IDbRepository<TEntity> 
        where TEntity : class
    {
        private readonly DbContext dbContext;
        private readonly IDbSet<TEntity> dbSet;

        public DbRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> All()
        {
            return dbSet.AsQueryable();
        }

        public TEntity Find(object id)
        {
            return dbSet.Find(id);
        }

        public TEntity Add(TEntity entity)
        {
            return ChangeState(entity, EntityState.Added);
        }

        public TEntity Update(TEntity entity)
        {
            return ChangeState(entity, EntityState.Modified);
        }

        public void Remove(TEntity entity)
        {
            ChangeState(entity, EntityState.Deleted);
        }

        public TEntity Remove(object id)
        {
            var entity = Find(id);

            Remove(entity);

            return entity;
        }

        public int SaveChanges()
        {
           return dbContext.SaveChanges();
        }

        private TEntity ChangeState(TEntity entity, EntityState state)
        {
            var entry = dbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            entry.State = state;

            return entity;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}