using Data.Database;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
