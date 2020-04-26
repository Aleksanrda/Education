using BabyLife.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BabyLife.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> babyLifeDbSet;

        private readonly BabyLifeDbContext babyLifeRepositoryContext;

        public Repository(BabyLifeDbContext babyLifeRepositoryContext)
        {
            this.babyLifeRepositoryContext = babyLifeRepositoryContext;
            this.babyLifeDbSet = babyLifeRepositoryContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return babyLifeDbSet;
        }

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression)
        {
            return babyLifeDbSet.Where(expression);
        }

        public void Create(TEntity entity)
        {
            babyLifeDbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            babyLifeDbSet.Attach(entity);
            babyLifeRepositoryContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (babyLifeRepositoryContext.Entry(entity).State == EntityState.Detached)
            {
                babyLifeDbSet.Attach(entity);
            }

            babyLifeDbSet.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = babyLifeDbSet.Find(id);
            Delete(entityToDelete);
        }

        public TEntity GetByID(object id)
        {
            return babyLifeDbSet.Find(id);
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = babyLifeDbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }


        public IQueryable<TEntity> GetAllLazyLoad(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children)
        {
            children.ToList().ForEach(x => babyLifeDbSet.Include(x).Load());
            return babyLifeDbSet;
        }
    }
}
