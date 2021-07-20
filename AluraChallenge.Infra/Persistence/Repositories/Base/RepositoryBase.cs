using AluraChallenge.Domain.Entities.Base;
using AluraChallenge.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AluraChallenge.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;

        }

        public async Task<TEntity> GetByIdAsync(string id, bool asNoTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            if (includeProperties != null)
            {
                try
                {
                    return await GetAll(asNoTracking, includeProperties).FirstOrDefaultAsync(x => x.Id == id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetAll(bool asNoTracking = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties != null)
            {
                query = includeProperties(query);
            }

            if (asNoTracking)
            {
                return query.AsNoTracking();
            }

            return query;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public IQueryable<TEntity> GetAllBy(bool asNoTracking = true, Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            return GetAll(asNoTracking, includeProperties).Where(where);
        }

        public IQueryable<TEntity> GetAllOrderBy<TKey>(bool asNoTracking = true, Expression<Func<TEntity, TKey>> ordem = null, bool ascendente = true, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeProperties = null)
        {
            return ascendente ? GetAll(asNoTracking, includeProperties).OrderBy(ordem) : GetAll(asNoTracking, includeProperties).OrderByDescending(ordem);
        }
    }
}
