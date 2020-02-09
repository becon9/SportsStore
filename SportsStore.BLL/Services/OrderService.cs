using System.Collections.Generic;
using System.Linq;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Interfaces;
using SportsStore.DAL.Entities;
using SportsStore.DAL.Interfaces;
using SportsStore.Infrastructure.Interfaces;

namespace SportsStore.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderDto> Orders
        {
            get
            {
                IEnumerable<Order> orders = _orderRepository.Orders;

                IEnumerable<OrderDto> ordersDto = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);

                return ordersDto;
            }
        }

        public void SaveOrder(OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            _orderRepository.SaveOrder(order);
        }

        public void MarkShipped(int orderId)
        {
            Order order = _orderRepository.Orders
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                order.Shipped = true;
                _orderRepository.SaveOrder(order);
            }
        }
    }
}