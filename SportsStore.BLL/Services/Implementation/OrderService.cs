using Microsoft.EntityFrameworkCore;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.DAL;
using SportsStore.DAL.Entities;
using SportsStore.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace SportsStore.BLL.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void MarkShipped(int orderId)
        {
            Order order = _uow.Orders.GetById(orderId);
            if (order != null)
            {
                order.Shipped = true;
                _uow.Orders.Update(order);
            }
        }

        public IEnumerable<OrderDto> GetNotShippedOrders()
        {
            IEnumerable<Order> orders = _uow.Orders.GetAll(predicate: order => !order.Shipped);

            IEnumerable<OrderDto> orderDtos = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);

            return orderDtos;
        }

        public OrderDto AddProductToLine(OrderDto orderDto)
        {
            Order order = _mapper.Map<OrderDto, Order>(orderDto);
            order = _uow.Orders.AddProductToLine(order);
            orderDto = _mapper.Map<Order, OrderDto>(order);
            return orderDto;
        }

        public void Add(OrderDto entity)
        {
            Order order = _mapper.Map<OrderDto, Order>(entity);
            _uow.Orders.Add(order);
        }

        public void Update(OrderDto entity)
        {
            Order order = _mapper.Map<OrderDto, Order>(entity);
            _uow.Orders.Update(order);
        }

        public void Remove(OrderDto entity)
        {
            Remove(entity.Id);
        }

        public void Remove(int id)
        {
            var order = new Order {Id = id};
            _uow.Orders.Remove(order);
        }

        public OrderDto GetById(int id)
        {
            Order order = _uow.Orders.GetById(id);
            OrderDto orderDto = _mapper.Map<Order, OrderDto>(order);
            return orderDto;
        }

        public IEnumerable<OrderDto> GetAll()
        {
            IEnumerable<Order> orders = _uow.Orders.GetAll(include: queryable => queryable
                .Include(o => o.Lines)
                .ThenInclude(l => l.Product));

            IEnumerable<OrderDto> ordersDto = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);

            return ordersDto;
        }

        public int Count()
        {
            return _uow.Orders.Count();
        }
    }
}