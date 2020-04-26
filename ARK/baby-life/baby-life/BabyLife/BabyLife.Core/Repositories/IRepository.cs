using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BabyLife.Core.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(object id);

        TEntity GetByID(object id);

        IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> GetAllLazyLoad(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children);
    }
}
