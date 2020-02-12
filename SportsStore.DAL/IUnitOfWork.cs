using SportsStore.DAL.Interfaces;

namespace SportsStore.DAL
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
    }
}