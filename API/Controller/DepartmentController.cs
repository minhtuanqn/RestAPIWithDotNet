using Business.Dto;
using Business.Service;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Department> departments = await _departmentService.GetAllAsync();
                return new JsonResult(departments);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new JsonResult(null);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            try
            {
                DepartmentDTO dto = await _departmentService.findByIdAsync(id);
                if(dto != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, dto, "Find successfully"));
                }    
                return new JsonResult(new ResponseModelDTO(400, dto, "Not found any result"));

            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }

        }
    }
}
