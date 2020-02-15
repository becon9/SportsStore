using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        void AddProductToLine(Order order);
    }
}