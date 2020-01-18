using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportsStoreTests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(repo => repo.Products).Returns((new Product[]
            {
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" },
            }).AsQueryable());

            var controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };

            //Act
            var result = controller.List(2).ViewData.Model as ProductsListViewModel;

            //Assert
            Product[] products = result.Products.ToArray();
            Assert.True(products.Length == 2);
            Assert.Equal("P4", products[0].Name);
            Assert.Equal("P5", products[1].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();
            mock.Setup(repo => repo.Products).Returns((new Product[]
            {
                new Product { ProductId = 1, Name = "P1" },
                new Product { ProductId = 2, Name = "P2" },
                new Product { ProductId = 3, Name = "P3" },
                new Product { ProductId = 4, Name = "P4" },
                new Product { ProductId = 5, Name = "P5" },
            }).AsQueryable);

            var controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };

            //Act
            var result = controller.List(2).ViewData.Model as ProductsListViewModel;

            //Assert
            PagingInfo pagingInfo = result.PagingInfo;
            Assert.Equal(2, pagingInfo.CurrentPage);
            Assert.Equal(3, pagingInfo.ItemsPerPage);
            Assert.Equal(5, pagingInfo.TotalItems);
            Assert.Equal(2, pagingInfo.TotalPages);
        }
    }
}
