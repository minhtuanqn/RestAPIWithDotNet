using Data.Entity;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> FindByEmail(string email);
    }
}
