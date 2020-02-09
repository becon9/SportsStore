using System.Collections.Generic;
using System.Linq;
using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}