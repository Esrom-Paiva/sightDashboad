using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories.Interface
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        TEntity GetById(Expression<Func<TEntity, bool>> expression = null);

        List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null);

        void Add(TEntity entity);

        void Delete(TEntity entity);


    }
}
