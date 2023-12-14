using Emarket.Domain.RabbitMq.Models;
using EMarket.Application.Services.RabbitMq.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RabbitMqController : Controller
    {
        private readonly IMqService _mqService;

        public RabbitMqController(IMqService mqService)
        {
            _mqService = mqService;
        }

        [HttpGet]
        public bool Send(string message)
        {
            MyRequestModel requestModel = new()
            {
                HostName = "localhost",
                Queue = "Pdp",
                RoutingKey = "Pdp",
                Message = message
            };
            return _mqService.Send(requestModel);
        }
        [HttpGet]
        public async Task<object> GetAsync()
        {
            string localhost = "localhost";
            string queue = "Pdp";
            return await _mqService.GetAsync(localhost, queue);
        }
    }
}
