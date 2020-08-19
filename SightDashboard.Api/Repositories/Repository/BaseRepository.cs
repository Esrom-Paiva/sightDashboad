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
        protected DbSet<TEntity> _dbSet;

        private readonly BaseContext _context;

        public BaseRepository(BaseContext baseContext)
        {
            _context = baseContext;
            _dbSet = _context.Set<TEntity>();

        }

        public virtual void Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public virtual void Put(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            return query.FirstOrDefault(expression);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (includeExpressions.Count() > 0)
            {
                query = includeExpressions.Aggregate(query, (current, expressionInclude) => current.Include(expressionInclude));
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
                return query.FirstOrDefault();
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

        public List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (includeExpressions.Count() > 0)
            {
                query = includeExpressions.Aggregate(query, (current, expressionInclude) => current.Include(expressionInclude));
            }
            return query.ToList();
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (includeExpressions.Count() > 0)
            {
                query = includeExpressions.Aggregate(query, (current, expressionInclude) => current.Include(expressionInclude));
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return query.ToList();
        }

    }
}
