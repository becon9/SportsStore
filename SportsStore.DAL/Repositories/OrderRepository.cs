using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsStore.DAL.Context;
using SportsStore.DAL.Entities;
using SportsStore.DAL.Interfaces;

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

        public IQueryable<Order> Orders => _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderId == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}