using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // GET api/values  
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid request");
            }

            if (_authService.Authenticate(user.UserName, user.Password))
            {
                var token = _authService.GenerateSecurityToken(user.UserName, user.Password);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
