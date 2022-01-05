using API.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace API.Config.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public JWTMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["X-Tuan-Token"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                try
                {
                    AttachAccountToContext(context, token);
                    await _next(context);
                }
                catch (Exception e)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsJsonAsync(new { Message = e.Message, StatusCode = StatusCodes.Status400BadRequest });
                }

            }
            else
            {
                string api = context.Request.Path.ToString();
                if (!api.Contains("auth"))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsJsonAsync(new { Message = "Unauthorized", StatusCode = StatusCodes.Status401Unauthorized });
                }
                else
                {
                    await _next(context);
                }    
            } 
        }

        private void AttachAccountToContext(HttpContext context, string token)
        {
            try
            {
                SecurityToken validatedToken = new TokenHelper().ValidateToken(_configuration, token);
                var jwtToken = (JwtSecurityToken) validatedToken;
                var accountId = jwtToken.Claims.First(x => x.Type == "id").Value;
                context.Items["User"] = new { id = accountId };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
