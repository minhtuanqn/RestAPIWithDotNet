using Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> FindByEmailAsync(string email);
        public Task<List<User>> GetAllByDepartmentIdAsync(Guid departmentId);
    }
}
