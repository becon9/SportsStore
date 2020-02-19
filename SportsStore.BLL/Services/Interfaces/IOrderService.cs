using System.Collections.Generic;
using SportsStore.BLL.DTO;

namespace SportsStore.BLL.Services.Interfaces
{
    public interface IOrderService : IService<OrderDto>
    {
        void MarkShipped(int orderId);
        IEnumerable<OrderDto> GetNotShippedOrders();
        OrderDto AddProductToLine(OrderDto order);
    }
}