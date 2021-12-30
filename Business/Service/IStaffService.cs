using Business.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IStaffService
    {
        public Task<List<StaffDTO>> GetAllAsync();
        public Task<StaffDTO> findByIdAsync(Guid id);
        public Task<StaffDTO> createAsync(StaffDTO dto);
        public Task<StaffDTO> deleteByIdAsync(Guid id);
        public Task<StaffDTO> updateAsync(StaffDTO dto);
    }
}
