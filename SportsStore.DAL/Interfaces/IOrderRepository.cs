using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        void AddProductToLine(Order order);
    }
}