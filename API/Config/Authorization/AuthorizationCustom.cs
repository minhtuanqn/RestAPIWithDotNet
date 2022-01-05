using Business.Const;
using Business.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace API.Config.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationCustom : Attribute, IAuthorizationFilter
    {
        public RoleEnum[] roles { get; set; }

        public AuthorizationCustom(RoleEnum[] roles)
        {
            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var account = context.HttpContext.Items["User"];
            bool isApproved = false;
            if(account != null)
            {
                string role = account?.GetType().GetProperty("role")
                    ?.GetValue(account, null).ToString();
                List<RoleEnum> authorList = new List<RoleEnum>(roles);
                foreach(RoleEnum roleElement in authorList)
                {
                    if (roleElement.ToString().Equals(role))
                    {
                        isApproved = true;
                        break;
                    }
                }
                
            }
            if(!isApproved)
            {
                context.Result = new JsonResult(new ResponseModelDTO(401, null, StatusCodes.Status401Unauthorized.ToString()));
            }
        }
    }
}
