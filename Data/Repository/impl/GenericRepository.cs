using Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        public AppDbContext GetAppDbContext() => _dbContext;

        public DbSet<T> GetEntity() => _entities;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _entities.ToListAsync();
            } catch(Exception e)
            {
                if(_dbContext != null)
                {
                    await _dbContext.DisposeAsync();
                }
                throw new Exception(e.Message);
            }
        }

        public async Task<T> findByIdAsync(Guid id)
        {
            try
            {
                return await _entities.FindAsync(id);
            }
            catch(Exception e)
            {
                if (_dbContext != null)
                {
                    await _dbContext.DisposeAsync();
                }
                throw new Exception(e.Message);
            }
        }
    }
}
