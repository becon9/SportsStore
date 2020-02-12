using SportsStore.DAL.Interfaces;

namespace SportsStore.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productsRepository;

        public UnitOfWork(IOrderRepository orderRepository, IProductRepository productsRepository)
        {
            _orderRepository = orderRepository;
            _productsRepository = productsRepository;
        }


        public IOrderRepository Orders
        {
            get { return _orderRepository; }
        }

        public IProductRepository Products
        {
            get { return _productsRepository; }
        }
    }
}