using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.WEB.Controllers;
using SportsStore.WEB.Models.ViewModels;
using Xunit;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetProductsWithImages()).Returns((new[]
            {
                new ProductDto { ProductId = 1, Name = "P1" },
                new ProductDto { ProductId = 2, Name = "P2" },
                new ProductDto { ProductId = 3, Name = "P3" },
                new ProductDto { ProductId = 4, Name = "P4" },
                new ProductDto { ProductId = 5, Name = "P5" },
            }).AsQueryable());

            var controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };

            //Act
            var result = controller.List(null, 2).ViewData.Model as ProductsListViewModel;

            //Assert
            ProductDto[] products = result?.Products.ToArray();
            Assert.True(products != null && products.Length == 2);
            Assert.Equal("P4", products[0].Name);
            Assert.Equal("P5", products[1].Name);
        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetAll()).Returns((new[]
            {
                new ProductDto { ProductId = 1, Name = "P1" },
                new ProductDto { ProductId = 2, Name = "P2" },
                new ProductDto { ProductId = 3, Name = "P3" },
                new ProductDto { ProductId = 4, Name = "P4" },
                new ProductDto { ProductId = 5, Name = "P5" },
            }).AsQueryable());

            var controller = new ProductController(mock.Object)
            {
                PageSize = 3
            };

            //Act
            var result = controller.List(null, 2).ViewData.Model as ProductsListViewModel;

            //Assert
            PagingInfo pagingInfo = result?.PagingInfo;
            Assert.Equal(2, pagingInfo?.CurrentPage);
            Assert.Equal(3, pagingInfo?.ItemsPerPage);
            Assert.Equal(5, pagingInfo?.TotalItems);
            Assert.Equal(2, pagingInfo?.TotalPages);
        }

        [Fact]
        public void Can_Filter_Product()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetProductsWithImages()).Returns((new[]
            {
                new ProductDto { ProductId = 1, Name = "P1", Category = "Cat1" },
                new ProductDto { ProductId = 2, Name = "P2", Category = "Cat2" },
                new ProductDto { ProductId = 3, Name = "P3", Category = "Cat1" },
                new ProductDto { ProductId = 4, Name = "P4", Category = "Cat2" },
                new ProductDto { ProductId = 5, Name = "P5", Category = "Cat3" },
            }).AsQueryable());

            var productController = new ProductController(mock.Object) { PageSize = 3 };

            //Act
            ProductDto[] result =
                (productController.List("Cat2", 1).ViewData.Model as ProductsListViewModel)
                ?.Products.ToArray();

            //Assert
            Assert.Equal(2, result?.Length);
            Assert.True(result?[0]?.Name == "P2" && result[0].Category == "Cat2");
            Assert.True(result[1]?.Name == "P4" && result[1].Category == "Cat2");
        }

        [Fact]
        public void Generate_Category_Specific_Product_Count()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetProductsWithImages()).Returns(new[]
            {
                new ProductDto { ProductId = 1, Name = "P1", Category = "Cat1" },
                new ProductDto { ProductId = 2, Name = "P2", Category = "Cat2" },
                new ProductDto { ProductId = 3, Name = "P3", Category = "Cat1" },
                new ProductDto { ProductId = 4, Name = "P4", Category = "Cat2" },
                new ProductDto { ProductId = 5, Name = "P5", Category = "Cat3" },
            }.AsQueryable());

            mock.Setup(service => service.GetAll()).Returns(mock.Object.GetProductsWithImages());

            var target = new ProductController(mock.Object) { PageSize = 3 };

            ProductsListViewModel GetModel(ViewResult result) => result?.ViewData?.Model as ProductsListViewModel;

            //Act
            int? res1 = GetModel(target.List("Cat1"))?.PagingInfo.TotalItems;
            int? res2 = GetModel(target.List("Cat2"))?.PagingInfo.TotalItems;
            int? res3 = GetModel(target.List("Cat3"))?.PagingInfo.TotalItems;
            int? resAll = GetModel(target.List(null))?.PagingInfo.TotalItems;

            //Assert
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);
        }
    }
}
