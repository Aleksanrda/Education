using Babylife.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BabyLife.DataAccess.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> babyLifeDbSet;

        private BabyLifeDbContext babyLifeRepositoryContext;

        public RepositoryBase(BabyLifeDbContext babyLifeRepositoryContext)
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
    }
}
