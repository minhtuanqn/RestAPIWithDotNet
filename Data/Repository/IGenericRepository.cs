using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IGenericRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> findByIdAsync(Guid id);
        public Task<T> deleteByIdAsync(Guid id);
        public Task<T> addAsync(T entity);
        public Task<T> updateAsync(T entity);
    }
}
