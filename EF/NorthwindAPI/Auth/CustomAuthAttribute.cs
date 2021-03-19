using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NorthwindAPI.Auth
{
    public class CustomAuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Permissions { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (string.IsNullOrEmpty(Permissions))
            {
                if (context.HttpContext.User.Identity.IsAuthenticated)
                    return;
            }

            var userName = context.HttpContext.User.Identity.Name;
            var userRoles = context.HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            var requiredPermissions = Permissions.Split(",");

            foreach (var x in requiredPermissions)
            {
                if (userRoles.Contains(x))
                    return;
            }

            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
