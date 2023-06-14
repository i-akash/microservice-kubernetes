using System.Net;
using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaymentController : ControllerBase
    {

        private readonly ILogger<PaymentController> _logger;

        private readonly IBus _bus;

        private readonly HttpClient _httpClient;

        private readonly IConfiguration _configuaration;


        public PaymentController(ILogger<PaymentController> logger, IBus bus, HttpClient httpClient, IConfiguration configuaration)
        {
            _logger = logger;
            _bus = bus;
            _httpClient = httpClient;
            _configuaration = configuaration;
        }

        [HttpGet]
        public async Task<ActionResult> MakePayment(Guid orderId)
        {

            var response = await _httpClient.GetAsync($"http://{_configuaration["AuthServer"]}/Authentication/Validate");

            if(!(response.StatusCode == HttpStatusCode.OK))
            {
                _logger.LogError($"Customer is not authorized to make payment!, {response.StatusCode}");

                throw new Exception("Is not authorized");
            }

            try
            {
                await _bus.Publish<IShipEvent>(new { OrderId = orderId });
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed publishing event :{orderId},\n Error: {e.Message}");
            }

            try
            {
                await _bus.Send<IShipEvent>(new { OrderId = orderId });
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed sending event :{orderId},\n Error: {e.Message}");
            }

            _logger.LogInformation($"published event :{orderId}");

            return Ok(true);
        }
    }
}