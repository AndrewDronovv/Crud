using Microsoft.AspNetCore.Mvc;

namespace Crud.WebApi.Controllers
{
    [Route("healthy")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Healthy");
        }
    }
}
