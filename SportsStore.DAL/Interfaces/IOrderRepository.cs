using System.Linq;
using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Interfaces
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}