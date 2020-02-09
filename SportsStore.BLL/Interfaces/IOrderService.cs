using System.Collections.Generic;
using System.Linq;
using SportsStore.BLL.DTO;

namespace SportsStore.BLL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> Orders { get; }
        void SaveOrder(OrderDto orderDto);

        void MarkShipped(int orderId);
    }
}