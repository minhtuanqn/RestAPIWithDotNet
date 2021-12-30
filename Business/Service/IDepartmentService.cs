using Business.Dto;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IDepartmentService
    {
        public Task<List<DepartmentDTO>> GetAllAsync();
        public Task<DepartmentDTO> findByIdAsync(Guid id);
        public Task<DepartmentDTO> createAsync(DepartmentDTO dto);
        public Task<DepartmentDTO> deleteByIdAsync(Guid id);
        public Task<DepartmentDTO> updateAsync(DepartmentDTO dto);
    }

}
