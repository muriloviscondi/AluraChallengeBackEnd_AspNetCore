using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AluraChallenge.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(string id, bool asNoTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);

        IQueryable<TEntity> GetAll(bool asNoTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);

        Task InsertAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Remove(TEntity entity);

        IQueryable<TEntity> GetAllBy(bool asNoTracking = true, Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);

        IQueryable<TEntity> GetAllOrderBy<TKey>(bool asNoTracking = true, Expression<Func<TEntity, TKey>> ordem = null, bool ascendente = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);

        IQueryable<TEntity> GetAllAndOrderBy<TKey>(bool asNoTracking = true, Expression<Func<TEntity, bool>> where = null, Expression<Func<TEntity, TKey>> ordem = null, bool ascendente = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null);
    }
}
