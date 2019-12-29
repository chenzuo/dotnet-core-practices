using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProtectedController : ControllerBase
    {
        // GET api/protected/home
        [HttpGet("home", Order = 0)]
        public IActionResult Home()
        {
            return new OkObjectResult(new { result = true });
        }
    }
}