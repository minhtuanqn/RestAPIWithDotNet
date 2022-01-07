using Business.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service
{
    public interface IUserService
    {
        public Task<List<UserDTO>> GetAllAsync();
        public Task<UserDTO> FindByIdAsync(Guid id);
        public Task<UserDTO> CreateAsync(UserDTO dto);
        public Task<UserDTO> DeleteByIdAsync(Guid id);
        public Task<UserDTO> UpdateAsync(UserDTO dto);
        public Task<UserDTO> FindByEmailAsync(string email);
        public Task<List<UserDTO>> GetAllByDepartmentIdAsync(Guid id);

    }
}
