using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task5.Core.Repositories;

namespace Task5.DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> task5DbSet;

        private Task5DbContext task5RepositoryContext;

        public Repository(Task5DbContext task5RepositoryContext)
        {
            this.task5RepositoryContext = task5RepositoryContext;
            this.task5DbSet = task5RepositoryContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return task5DbSet;
        }

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return task5DbSet.Where(expression);
        }

        public void Create(TEntity entity)
        {
            task5DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            task5DbSet.Attach(entity);
            task5RepositoryContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (task5RepositoryContext.Entry(entity).State == EntityState.Detached)
            {
                task5DbSet.Attach(entity);
            }

            task5DbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = task5DbSet.Find(id);
            Delete(entityToDelete);
        }

        public TEntity GetByID(object id)
        {
            return task5DbSet.Find(id);
        }
    }
}
