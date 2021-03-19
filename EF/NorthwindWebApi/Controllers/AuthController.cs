using Microsoft.AspNetCore.Mvc;
using NorthwindWebApi.Models;

namespace NorthwindWebApi.Controllers
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
            throw new System.Exception("SAdasdas");
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
}
