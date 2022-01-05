using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IGenericRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> FindByIdAsync(Guid id);
        public Task<T> DeleteByIdAsync(Guid id);
        public Task<T> AddAsync(T entity);
        public Task<T> UpdateAsync(T entity);
    }
}
