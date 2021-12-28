﻿using Business.Dto;
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
        private IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDTO> findByIdAsync(Guid id)
        {
            Department department = await _departmentRepository.findByIdAsync(id);
            if (department != null)
            {
                DepartmentDTO dto = Mapper.GetMapper().Map<DepartmentDTO>(department);
                return dto;
            }
            
            return null;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            List<Department> departments = new List<Department>();
            IEnumerable<Department> departmentsENums = await _departmentRepository.GetAllAsync();
            foreach(Department department in departmentsENums)
            {
                departments.Add(department);
            }
            return departments;
        }
    }
}
