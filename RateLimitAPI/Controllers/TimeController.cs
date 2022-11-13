using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using RateLimitAPI.Services;

namespace RateLimitAPI.Controllers
{
    [ApiController]
    public class TimeController : Controller
    {
        IGetTimeService _service;

        public TimeController(IGetTimeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("[controller]/time-current")]
        [EnableRateLimiting("LimiterPolicy")]
        public IActionResult Index()
        {
            return Ok(_service.currentTime());
        }
    }
}