using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RemAcademy.Business.Operations.Order.Dtos;
using RemAcademy.Business.Operations.Order;

namespace RemAcademy.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: api/order
        [HttpPost]
        public async Task<IActionResult> CreateOrder( OrderDto orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _orderService.CreateOrder(orderDto);
            return Ok("Order created successfully.");
        }

        // GET: api/order/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrder(id);
            if (order == null)
                return NotFound("Order not found.");

            return Ok(order);
        }
    }
}
