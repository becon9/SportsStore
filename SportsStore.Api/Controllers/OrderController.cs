using Microsoft.AspNetCore.Mvc;
using SportsStore.Api.Models;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;

namespace SportsStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult AddOrder(OrderCreationRequestModel model)
        {
            var orderDto = new OrderDto()
            {
                Name = model.Name,
                Line1 = model.Address,
                Line2 = model.Email,
                City = model.City,
                Lines = model.CartLines,
                Zip = model.Zip,
                Shipped = false,
                Country = "",
                Line3 = "",
                State = "",
                GiftWrap = false,
            };
            
            orderDto = _orderService.AddProductToLine(orderDto);
            
            return Ok(orderDto.OrderId);
        }
    }
}