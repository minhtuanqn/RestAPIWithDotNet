using Business.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Utils
{
    public class TokenHelper 
    {
        public string BuildToken(IConfiguration configuration, UserDTO dto)
        {
            var credentials = GetCredentials(configuration);
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("ID", dto.id.ToString()));
            permClaims.Add(new Claim("EMAIL", dto.email));
            permClaims.Add(new Claim("ROLE", dto.role));
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
              configuration["Jwt:Issuer"],
              permClaims,
              expires: DateTime.Now.AddMinutes(1440),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public SecurityToken ValidateToken(IConfiguration configuration, string token)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            // check token with security
            try
            {
                ClaimsPrincipal claims = new JwtSecurityTokenHandler()
                    .ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
                return validatedToken;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Generate securityKey from Key in Config and then encode
        public SigningCredentials GetCredentials(IConfiguration configuration)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }

        public ClaimsPrincipal getClaims(string token, IConfiguration configuration)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                // Get securityKey from appsetting json
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

                // Check token
                ClaimsPrincipal claims = handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
                return claims;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
