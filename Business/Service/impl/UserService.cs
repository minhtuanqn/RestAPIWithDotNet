using Business.Dto;
using Business.Utils;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IDepartmentRepository departmentRepository;
        
        public UserService(IUserRepository userRepository,
            IDepartmentRepository departmentRepository)
        {
            this.userRepository = userRepository;
            this.departmentRepository = departmentRepository;
        }

        public async Task<UserDTO> CreateAsync(UserDTO dto)
        {
            Department existedDep = await departmentRepository.FindByIdAsync(dto.departmentId);
            if(existedDep != null)
            {
                User user = Mapper.GetMapper().Map<User>(dto);
                user.id = Guid.NewGuid();
                user.status = true;
                User insertedUser = await userRepository.AddAsync(user);
                return Mapper.GetMapper().Map<UserDTO>(insertedUser);
            }
            return null;
        }

        public async Task<UserDTO> DeleteByIdAsync(Guid id)
        {
            User user = await userRepository.DeleteByIdAsync(id);
            if (user != null)
            {
                UserDTO dto = Mapper.GetMapper().Map<UserDTO>(user);
                return dto;
            }
            return null;
        }

        public async Task<UserDTO> FindByEmail(string email)
        {
            User user = await userRepository.FindByEmail(email);
            if (user != null)
            {
                UserDTO dto = Mapper.GetMapper().Map<UserDTO>(user);
                return dto;
            }
            return null;
        }

        public async Task<UserDTO> FindByIdAsync(Guid id)
        {
            User user = await userRepository.FindByIdAsync(id);
            if (user != null)
            {
                UserDTO dto = Mapper.GetMapper().Map<UserDTO>(user);
                return dto;
            }

            return null;
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            List<UserDTO> users = new List<UserDTO>();
            IEnumerable<User> usersENums = await userRepository.GetAllAsync();
            foreach (User user in usersENums)
            {
                UserDTO dto = Mapper.GetMapper().Map<UserDTO>(user);
                users.Add(dto);
            }
            return users;
        }

        public async Task<UserDTO> UpdateAsync(UserDTO dto)
        {
            User existedUser = await userRepository.FindByIdAsync(dto.id);
            if (existedUser != null)
            {
                Department existedDep = await departmentRepository.FindByIdAsync(dto.departmentId); 
                if(existedDep != null)
                {
                    existedUser.firstName = dto.firstName;
                    existedUser.lastName = dto.lastName;
                    existedUser.age = dto.age;
                    existedUser.departmentId = dto.departmentId;
                    User updatedUser = await userRepository.UpdateAsync(existedUser);
                    return Mapper.GetMapper().Map<UserDTO>(updatedUser);
                }
            }
            return null;
        }
    }
}
