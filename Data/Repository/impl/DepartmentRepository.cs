using Data.Database;
using Data.Entity;

namespace Data.Repository.impl
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        private readonly AppDbContext dbContext;

        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
