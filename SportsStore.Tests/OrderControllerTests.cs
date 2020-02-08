using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Interfaces;
using SportsStore.WEB.Controllers;
using SportsStore.WEB.Models;
using Xunit;

namespace SportsStore.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void Cannot_Checkout_Empty_Cart()
        {
            //Arrange
            var mock = new Mock<IOrderService>();
            var cart = new Cart();
            var order = new OrderDto();
            var target = new OrderController(mock.Object, cart);

            //Act
            var result = target.Checkout(order) as ViewResult;

            //Assert
            mock.Verify(m => m.SaveOrder(It.IsAny<OrderDto>()), Times.Never);
            Assert.True(String.IsNullOrEmpty(result?.ViewName));
            Assert.False(result?.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            //Arrange
            var mock = new Mock<IOrderService>();
            var cart = new Cart();
            cart.AddItem(new ProductDto(), 1);
            var target = new OrderController(mock.Object, cart);
            target.ModelState.AddModelError("error", "error");

            //Act
            var result = target.Checkout(new OrderDto()) as ViewResult;

            //Assert
            mock.Verify(m => m.SaveOrder(It.IsAny<OrderDto>()), Times.Never);
            Assert.True(String.IsNullOrEmpty(result?.ViewName));
            Assert.False(result?.ViewData.ModelState.IsValid);
        }

        [Fact]
        public void Can_Checkout_And_Submit_Order()
        {
            //Arrange
            var mock = new Mock<IOrderService>();
            var cart = new Cart();
            cart.AddItem(new ProductDto(), 1);
            var target = new OrderController(mock.Object, cart);

            //Act
            var result = target.Checkout(new OrderDto()) as RedirectToActionResult;

            //Assert
            mock.Verify(m => m.SaveOrder(It.IsAny<OrderDto>()), Times.Once);
            Assert.Equal("Completed", result?.ActionName);
        }
    }
}