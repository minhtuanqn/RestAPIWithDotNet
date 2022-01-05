using API.Utils;
using Business.Dto;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace API.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController
    {
        private readonly IConfiguration config;
        private readonly IUserService userService;

        public AuthController(IConfiguration config, IUserService userService)
        {
            this.config = config;
            this.userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> LoginByEmail([EmailAddress] string email)
        {
            try
            {
                UserDTO dto = await userService.FindByEmail(email);
                if(dto != null)
                {
                    string token = new TokenHelper().BuildToken(config, dto);
                    return new JsonResult(new ResponseModelDTO(200, token, "OK"));
                }
                return new JsonResult(new ResponseModelDTO(400, null, "Authenticated faild"));

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return new JsonResult(new ResponseModelDTO(400, null, "Error"));
            }
        }

    }
}
