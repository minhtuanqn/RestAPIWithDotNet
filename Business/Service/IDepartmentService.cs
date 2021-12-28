using Business.Dto;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IDepartmentService
    {
        public Task<List<Department>> GetAllAsync();

        public Task<DepartmentDTO> findByIdAsync(Guid id);
    }

}
