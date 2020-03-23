using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Babylife.Core.Repositories
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class 
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(object id);

        TEntity GetByID(object id);
    }
}
