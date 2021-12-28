using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IGenericRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> findByIdAsync(Guid id);
    }
}
