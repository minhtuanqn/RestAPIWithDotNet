using API.Config.Authorization;
using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Const;

namespace API.Controller
{
    [Route("api/departments")]
    [ApiController]
    [AuthorizationCustom(new RoleEnum[] { RoleEnum.DEPARTMENT_ADMIN })]
    public class DepartmentController
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<DepartmentDTO> departments = await departmentService.GetAllAsync();
                return new JsonResult(new ResponseModelDTO(200, departments, "Find successfully"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new JsonResult(new ResponseModelDTO(400, new List<DepartmentDTO>(), "Error"));
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            try
            {
                DepartmentDTO existedDTO = await departmentService.FindByIdAsync(id);
                if(existedDTO != null)
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
                DepartmentDTO dto = await departmentService.DeleteByIdAsync(id);
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
        public async Task<IActionResult> Create(DepartmentDTO dto)
        {
            try
            {
                DepartmentDTO createdDep = await departmentService.CreateAsync(dto);
                if(createdDep != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, createdDep, "Create successfully"));
                }
                return new JsonResult(new ResponseModelDTO(400, createdDep, "Bad request"));
            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(DepartmentDTO dto)
        {
            try
            {
                DepartmentDTO updatedDep = await departmentService.UpdateAsync(dto);
                if (updatedDep != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, updatedDep, "Update successfully"));
                }
                return new JsonResult(new ResponseModelDTO(400, updatedDep, "Bad request"));
            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }
        }
    }
}
