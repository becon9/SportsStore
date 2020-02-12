using SportsStore.DAL.Context;
using SportsStore.DAL.Entities;
using SportsStore.DAL.Interfaces;
using System.Linq;

namespace SportsStore.DAL.Repositories
{
    public class OrderRepository : EFRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        /*public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }*/


        public void AddProductToLine(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderId == 0)
            {
                Add(order);
            }
            _context.SaveChanges();
        }
    }
}