using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlackboxFest.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<TEntity> dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void DeleteRange(TEntity entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAllExtenssion(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public async Task<TEntity> GetById(int? id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public TEntity GetByIdWithoutAsync(int? id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }


            return query.FirstOrDefault();
        }
        public TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }


            return query.SingleOrDefault();
        }

    }
}
