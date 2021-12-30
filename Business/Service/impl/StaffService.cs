using Business.Dto;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository staffRepository;
        private readonly IDepartmentRepository departmentRepository;
        
        public StaffService(IStaffRepository staffRepository,
            IDepartmentRepository departmentRepository)
        {
            this.staffRepository = staffRepository;
            this.departmentRepository = departmentRepository;
        }

        public async Task<StaffDTO> createAsync(StaffDTO dto)
        {
            Department existedDep = await departmentRepository.findByIdAsync(dto.departmentId);
            if(existedDep != null)
            {
                Staff staff = Mapper.GetMapper().Map<Staff>(dto);
                staff.id = Guid.NewGuid();
                staff.status = true;
                Staff insertedStaff = await staffRepository.addAsync(staff);
                return Mapper.GetMapper().Map<StaffDTO>(insertedStaff);
            }
            return null;
        }

        public async Task<StaffDTO> deleteByIdAsync(Guid id)
        {
            Staff staff = await staffRepository.deleteByIdAsync(id);
            if (staff != null)
            {
                StaffDTO dto = Mapper.GetMapper().Map<StaffDTO>(staff);
                return dto;
            }
            return null;
        }

        public async Task<StaffDTO> findByIdAsync(Guid id)
        {
            Staff staff = await staffRepository.findByIdAsync(id);
            if (staff != null)
            {
                StaffDTO dto = Mapper.GetMapper().Map<StaffDTO>(staff);
                return dto;
            }

            return null;
        }

        public async Task<List<StaffDTO>> GetAllAsync()
        {
            List<StaffDTO> staffs = new List<StaffDTO>();
            IEnumerable<Staff> staffsENums = await staffRepository.GetAllAsync();
            foreach (Staff staff in staffsENums)
            {
                StaffDTO dto = Mapper.GetMapper().Map<StaffDTO>(staff);
                staffs.Add(dto);
            }
            return staffs;
        }

        public async Task<StaffDTO> updateAsync(StaffDTO dto)
        {
            Staff existedStaff = await staffRepository.findByIdAsync(dto.id);
            if (existedStaff != null)
            {
                Department existedDep = await departmentRepository.findByIdAsync(dto.departmentId); 
                if(existedDep != null)
                {
                    existedStaff.firstName = dto.firstName;
                    existedStaff.lastName = dto.lastName;
                    existedStaff.age = dto.age;
                    existedStaff.departmentId = dto.departmentId;
                    Staff updatedStaff = await staffRepository.updateAsync(existedStaff);
                    return Mapper.GetMapper().Map<StaffDTO>(updatedStaff);
                }
            }
            return null;
        }
    }
}
