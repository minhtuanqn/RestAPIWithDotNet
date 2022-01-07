using Business.Dto;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDTO> CreateAsync(DepartmentDTO dto)
        {
            Department department = Mapper.GetMapper().Map<Department>(dto);
            department.id = Guid.NewGuid();
            department.status = true;
            Department insertedDep = await departmentRepository.AddAsync(department);
            return Mapper.GetMapper().Map<DepartmentDTO>(insertedDep);
        }

        public async Task<DepartmentDTO> UpdateAsync(DepartmentDTO dto)
        {
            Department existedDep = await departmentRepository.FindByIdAsync(dto.id);
            if(existedDep != null)
            {
                existedDep.name = dto.name;
                Department updatedDep = await departmentRepository.UpdateAsync(existedDep);
                return Mapper.GetMapper().Map<DepartmentDTO>(updatedDep);
            }
            return null;   
        }

        public async Task<DepartmentDTO> DeleteByIdAsync(Guid id)
        {
            Department department = await departmentRepository.DeleteByIdAsync(id);
            if (department != null)
            {
                DepartmentDTO dto = Mapper.GetMapper().Map<DepartmentDTO>(department);
                return dto;
            }
            return null;
        }

        public async Task<DepartmentDTO> FindByIdAsync(Guid id)
        {
            Department department = await departmentRepository.FindByIdAsync(id);
            if (department != null)
            {
                DepartmentDTO dto = Mapper.GetMapper().Map<DepartmentDTO>(department);
                return dto;
            }
            
            return null;
        }

        public async Task<List<DepartmentDTO>> GetAllAsync()
        {
            List<DepartmentDTO> departments = new List<DepartmentDTO>();
            IEnumerable<Department> departmentsENums = await departmentRepository.GetAllAsync();
            foreach(Department department in departmentsENums)
            {
                DepartmentDTO dto = Mapper.GetMapper().Map<DepartmentDTO>(department);
                departments.Add(dto);
            }
            return departments;
        }

        
    }
}
