using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindData.Models;
using NorthwindWebApi.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWebApi.Controllers
{
    ///weatherforecast/ -> WeatherController
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("admin")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult GetForAdmin()
        {
            return Ok("admin");
        }

        [HttpGet]
        [Route("user")]
        [Authorize(Policy = "UsersOnly")]
        public IActionResult GetForUser()
        {
            return Ok("user");
        }

        [HttpGet]
        [Route("CustomAuth")]
        [CustomAuth(Permissions = "user")]
        public IActionResult CustomAuth()
        {
            return Ok("user");
        }
    }
}
