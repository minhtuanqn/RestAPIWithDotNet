using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/staffs")]
    [ApiController]
    public class StaffController
    {
        private readonly IStaffService staffService;
        public StaffController(IStaffService staffService)
        {
            this.staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<StaffDTO> staffs = await staffService.GetAllAsync();
                return new JsonResult(new ResponseModelDTO(200, staffs, "Find successfully"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new JsonResult(new ResponseModelDTO(400, new List<StaffDTO>(), "Error"));
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(Guid id)
        {
            try
            {
                StaffDTO existedDTO = await staffService.findByIdAsync(id);
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
                StaffDTO dto = await staffService.deleteByIdAsync(id);
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
        public async Task<IActionResult> Create(StaffDTO dto)
        {
            try
            {
                StaffDTO createdStaff = await staffService.createAsync(dto);
                if (createdStaff != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, createdStaff, "Create successfully"));
                }
                return new JsonResult(new ResponseModelDTO(400, createdStaff, "Bad request"));
            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(StaffDTO dto)
        {
            try
            {
                StaffDTO updatedStaff = await staffService.updateAsync(dto);
                if (updatedStaff != null)
                {
                    return new JsonResult(new ResponseModelDTO(200, updatedStaff, "Update successfully"));
                }
                return new JsonResult(new ResponseModelDTO(400, updatedStaff, "Bad request"));
            }
            catch (Exception e)
            {
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }
        }
    }
}

