using Business.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IDepartmentService
    {
        public Task<List<DepartmentDTO>> GetAllAsync();
        public Task<DepartmentDTO> FindByIdAsync(Guid id);
        public Task<DepartmentDTO> CreateAsync(DepartmentDTO dto);
        public Task<DepartmentDTO> DeleteByIdAsync(Guid id);
        public Task<DepartmentDTO> UpdateAsync(DepartmentDTO dto);
        
    }

}
