using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return Ok(true);
        }

        [HttpGet]
        public ActionResult Validate()
        {
            return Ok(true);
        }

    }
}