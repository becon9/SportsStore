using SportsStore.DAL.Entities;

namespace SportsStore.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order AddProductToLine(Order order);
    }
}