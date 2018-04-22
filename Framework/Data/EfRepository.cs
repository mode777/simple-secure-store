using Microsoft.EntityFrameworkCore;
using Security.Core.Interfaces;
using SimpleSecureStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureStore
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly StorageContext _dbContext;

        public EfRepository(StorageContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected DbContext DbContext => _dbContext;

        public async virtual Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async virtual Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async virtual Task<T> GetByKeyAsync(params object[] keys)
        {
            return await _dbContext.Set<T>().FindAsync(keys);
        }

        public async Task<T> GetSingleAsync(ISpecification<T> spec)
        {
            return await Query(spec).FirstOrDefaultAsync();
        }

        public async virtual Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec)
        {
            return await Query(spec).ToListAsync();
        }

        protected virtual IQueryable<T> Query(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria);
        }

        public async virtual Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
