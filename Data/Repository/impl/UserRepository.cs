using Data.Database;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.impl
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> FindByEmail(string email)
        {
            try
            {
                var users = await dbContext.users.Where(u => u.email.ToLower()
                                    .Equals(email.ToLower())).ToListAsync();
                return users.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
