using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N50Home.Api.Services;

namespace N50Home.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly UserOrderService _orderService;

        public OrdersController(UserOrderService userOrderService)
        {
            _orderService = userOrderService;
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get([FromRoute] Guid id) =>
            Ok(_orderService.GetUserOrdersByUserId(id));
    }
}