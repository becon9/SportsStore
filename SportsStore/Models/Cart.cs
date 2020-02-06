﻿using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class Cart
    {
        private List<CartLine> _lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = _lineCollection
                .Find(p => p.Product.ProductId == product.ProductId);
            if (line == null)
            {
                _lineCollection.Add(new CartLine
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

        public virtual void RemoveLine(Product product) =>
            _lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);

        public virtual decimal ComputeTotalValue() =>
            _lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() =>
            _lineCollection.Clear();

        public virtual IEnumerable<CartLine> Lines =>
            _lineCollection;
    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}