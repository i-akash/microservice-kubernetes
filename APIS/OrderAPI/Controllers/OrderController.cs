using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult ConfirmOrder()
        {
            var orderId = Guid.NewGuid();

            return Ok(orderId);
        }
    }
}