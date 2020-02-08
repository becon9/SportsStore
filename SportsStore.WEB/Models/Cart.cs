using System.Collections.Generic;
using System.Linq;
using SportsStore.BLL.DTO;

namespace SportsStore.WEB.Models
{
    public class Cart
    {
        private readonly List<CartLineDto> _lineCollection = new List<CartLineDto>();

        public virtual void AddItem(ProductDto product, int quantity)
        {
            CartLineDto line = _lineCollection
                .Find(p => p.Product.ProductId == product.ProductId);
            if (line == null)
            {
                _lineCollection.Add(new CartLineDto
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(ProductDto product) =>
            _lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public virtual decimal ComputeTotalValue() =>
            _lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() =>
            _lineCollection.Clear();

        public virtual IEnumerable<CartLineDto> Lines =>
            _lineCollection;
    }

    
}