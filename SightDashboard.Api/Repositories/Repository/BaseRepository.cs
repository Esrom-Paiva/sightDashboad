using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly BaseContext _context;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(BaseContext baseContext)
        {
            _context = baseContext;
            _dbSet = _context.Set<TEntity>();

        }
        public virtual void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            return query.ToList();
        } 
        public virtual List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (includeExpressions.Count() > 0)
            {
                query = includeExpressions.Aggregate(query, (current, expressionInclude) => current.Include(expressionInclude));
            }
            return query.ToList();
        }




        public virtual TEntity GetById(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            return query.FirstOrDefault(expression);
        }
    }
}
