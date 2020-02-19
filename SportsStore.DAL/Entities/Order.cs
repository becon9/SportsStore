using System.Collections.Generic;

namespace SportsStore.DAL.Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public ICollection<CartLine> Lines { get; set; }
        public bool Shipped { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public bool GiftWrap { get; set; }
    }

    public class CartLine : IEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}