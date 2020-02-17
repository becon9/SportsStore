using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.WEB.Controllers;
using Xunit;

namespace SportsStore.Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void Index_Contains_All_Products()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetAll()).Returns(new[]
            {
                new ProductDto {ProductId = 1, Name = "P1"},
                new ProductDto {ProductId = 2, Name = "P2"},
                new ProductDto {ProductId = 3, Name = "P3"},
            }.AsQueryable());

            var target = new AdminController(mock.Object);

            //Act
            ProductDto[] result = GetViewModel<IEnumerable<ProductDto>>(target.Index())?.ToArray();

            //Assert
            Assert.Equal(3, result?.Length);
            Assert.Equal("P1", result?[0].Name);
            Assert.Equal("P2", result?[1].Name);
            Assert.Equal("P3", result?[2].Name);
        }

        [Fact]
        public void Can_Edit_Product()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetAll()).Returns(new[]
            {
                new ProductDto {ProductId = 1, Name = "P1"},
                new ProductDto {ProductId = 2, Name = "P2"},
                new ProductDto {ProductId = 3, Name = "P3"}
            }.AsQueryable());

            var target = new AdminController(mock.Object);

            //Act
            var p1 = GetViewModel<ProductDto>(target.Edit(1));
            var p2 = GetViewModel<ProductDto>(target.Edit(2));
            var p3 = GetViewModel<ProductDto>(target.Edit(3));

            //Assert
            Assert.Equal(1, p1.ProductId);
            Assert.Equal(2, p2.ProductId);
            Assert.Equal(3, p3.ProductId);
        }

        [Fact]
        public void Cannot_Edit_Nonexistent_Product()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetAll()).Returns(new[]
            {
                new ProductDto {ProductId = 1, Name = "P1"},
                new ProductDto {ProductId = 2, Name = "P2"},
                new ProductDto {ProductId = 3, Name = "P3"}
            }.AsQueryable());

            var target = new AdminController(mock.Object);

            //Act
            var result = GetViewModel<ProductDto>(target.Edit(4));

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void Can_Save_Valid_Changes()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            var tempData = new Mock<ITempDataDictionary>();
            var target = new AdminController(mock.Object) {TempData = tempData.Object};
            var product = new ProductDto {Name = "Test"};

            //Act
            IActionResult result = target.Edit(product);

            //Assert
            mock.Verify(service => service.Add(product));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult)?.ActionName);
        }

        [Fact]
        public void Cannot_Save_Invalid_Changes()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            var target = new AdminController(mock.Object);
            var product = new ProductDto() {Name = "Test"};
            target.ModelState.AddModelError("error", "error");

            //Act
            IActionResult result = target.Edit(product);

            //Assert
            mock.Verify(service => service.Add(It.IsAny<ProductDto>()), Times.Never);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Can_Delete_Valid_Products()
        {
            //Arrange
            var product = new ProductDto() {ProductId = 2, Name = "Test"};
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetById(It.IsAny<int>())).Returns(product);
            
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            
            var target = new AdminController(mock.Object)
            {
                TempData = tempData
            };

            //Act
            target.Delete(product.ProductId);

            //Assert
            mock.Verify(service => service.Remove(product));
        }

        private static T GetViewModel<T>(IActionResult actionResult) where T : class
        {
            return (actionResult as ViewResult)?.ViewData.Model as T;
        }
    }
}