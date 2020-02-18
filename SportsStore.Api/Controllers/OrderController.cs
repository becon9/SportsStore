using Microsoft.AspNetCore.Mvc;
using SportsStore.Api.Models;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.Infrastructure.Interfaces;

namespace SportsStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<int> AddOrder(OrderCreationRequestModel model)
        {
            OrderDto orderDto = _mapper.Map<OrderCreationRequestModel, OrderDto>(model);

            orderDto = _orderService.AddProductToLine(orderDto);
            
            return Ok(orderDto.Id);
        }
    }
}