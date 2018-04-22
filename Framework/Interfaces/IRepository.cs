using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSecureStore
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByKeyAsync(params object[] keys);
        Task<T> GetSingleAsync(ISpecification<T> spec);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
