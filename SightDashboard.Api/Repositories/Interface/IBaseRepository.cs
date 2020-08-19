using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories.Interface
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        TEntity Get(Expression<Func<TEntity, bool>> expression = null);

        TEntity Get(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeExpressions);

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);

        List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions);

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeExpressions);

        void Add(TEntity entity);

        void Put(TEntity entity);

        void Delete(TEntity entity);


    }
}
