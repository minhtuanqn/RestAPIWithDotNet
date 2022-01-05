using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Const;

namespace API.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<UserDTO> users = await userService.GetAllAsync();
                return new JsonResult(new ResponseModelDTO(200, users, "Find successfully"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new JsonResult(new ResponseModelDTO(400, new List<UserDTO>(), "Error"));
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            try
            {
                UserDTO existedDTO = await userService.FindByIdAsync(id);
                if (existedDTO != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, existedDTO, "Find successfully"));
                }
                return new JsonResult(new ResponseModelDTO(400, existedDTO, "Not found any result"));

            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                UserDTO dto = await userService.DeleteByIdAsync(id);
                if (dto != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, dto, "Delete successfully"));
                }
                return new JsonResult(new ResponseModelDTO(400, dto, "Not found any result"));

            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO dto)
        {
            try
            {
                UserDTO createdUser = await userService.CreateAsync(dto);
                if (createdUser != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, createdUser, "Create successfully"));
                }
                return new JsonResult(new ResponseModelDTO(400, createdUser, "Bad request"));
            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserDTO dto)
        {
            try
            {
                UserDTO updatedUser = await userService.UpdateAsync(dto);
                if (updatedUser != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, updatedUser, "Update successfully"));
                }
                return new JsonResult(new ResponseModelDTO(400, updatedUser, "Bad request"));
            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }
        }
    }
}

