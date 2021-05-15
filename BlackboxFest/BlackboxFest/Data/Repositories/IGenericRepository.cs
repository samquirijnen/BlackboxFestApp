using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlackboxFest.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(int? id);
        TEntity GetByIdWithoutAsync(int? id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(TEntity entity);
        TEntity GetFirstOrDefault(
           Expression<Func<TEntity, bool>> filter = null,
           string includeProperties = null
           );
        TEntity GetSingleOrDefault(
         Expression<Func<TEntity, bool>> filter = null,
         string includeProperties = null
         );
        IEnumerable<TEntity> GetAllExtenssion(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = null
           );

    }
}
