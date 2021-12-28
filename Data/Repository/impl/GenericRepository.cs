using Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> entities;
        private readonly AppDbContext dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            entities = dbContext.Set<T>();
        }

        public AppDbContext GetAppDbContext() => dbContext;

        public DbSet<T> GetEntity() => entities;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await entities.ToListAsync();
            } catch(Exception e)
            {
                if(dbContext != null)
                {
                    await dbContext.DisposeAsync();
                }
                throw new Exception(e.Message);
            }
        }

        public async Task<T> findByIdAsync(Guid key)
        {
            try
            {
                return await entities.FindAsync(key);
            }
            catch(Exception e)
            {
                if (dbContext != null)
                {
                    await dbContext.DisposeAsync();
                }
                throw new Exception(e.Message);
            }
        }

        public async Task<T> deleteByIdAsync(Guid key)
        {
            try
            {
                T entity = await entities.FindAsync(key);
                if(entity != null)
                {
                    EntityEntry entry = entities.Remove(entity);
                    if(entry.State == EntityState.Deleted)
                    {
                        dbContext.SaveChanges();
                        return (T)entry.Entity;
                    }
                }
                return null;
            }
            catch(Exception e)
            {
                if(dbContext != null)
                {
                    await dbContext.DisposeAsync();
                }
                throw new Exception(e.Message);
            }
        }
    }
}
