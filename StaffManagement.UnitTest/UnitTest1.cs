using API.Controller;
using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace StaffManagement.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void validateDepartmentController()
        {
            DepartmentDTO dto = new DepartmentDTO();
            dto.id = Guid.Parse("123e4567-e89b-12d3-a456-426655440000");
            dto.name = "test";

            var mockDepService = new Mock<IDepartmentService>();
            var mockUserService = new Mock<IUserService>();
            mockDepService.Setup(service =>
            service.FindByIdAsync(Guid.Parse("123e4567-e89b-12d3-a456-426655440000"))).ReturnsAsync(dto);

            var controller = new DepartmentController(mockDepService.Object, mockUserService.Object);

            var result = controller.FindById(Guid.Parse("123e4567-e89b-12d3-a456-426655440000"));

            var viewResult = Assert.IsType<DepartmentDTO>(result);
        }
    }
}
