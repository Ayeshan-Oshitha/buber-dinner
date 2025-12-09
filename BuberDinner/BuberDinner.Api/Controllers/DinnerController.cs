using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("dinner")]
    public class DinnerController : ApiController
    {
        [HttpGet]
        public IActionResult GetDinner()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
