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

        public async Task<T> FindByIdAsync(Guid key)
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

        public async Task<T> DeleteByIdAsync(Guid key)
        {
            try
            {
                T entity = await entities.FindAsync(key);
                if(entity != null)
                {
                    EntityEntry entry = entities.Remove(entity);
                    if(entry.State == EntityState.Deleted)
                    {
                        await dbContext.SaveChangesAsync();
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

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                EntityEntry entry = await entities.AddAsync(entity);
                if(entry.State == EntityState.Added)
                {
                    await dbContext.SaveChangesAsync();
                    return (T)entry.Entity;
                }
                return null;
            }
            catch (Exception e)
            {
                if(dbContext != null)
                {
                    await dbContext.DisposeAsync();
                }
                throw new Exception(e.Message);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                EntityEntry entry = entities.Update(entity);
                if(entry.State == EntityState.Modified)
                {
                    await dbContext.SaveChangesAsync();
                    return (T)entry.Entity;
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
