using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            return Ok(request);
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            return Ok(request);
        }
    }
}
