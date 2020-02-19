using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Routing;
using Moq;
using SportsStore.BLL.DTO;
using SportsStore.WEB.Components;
using System.Collections.Generic;
using System.Linq;
using SportsStore.BLL.Services.Interfaces;
using Xunit;

namespace SportsStore.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //Arrange
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetAll()).Returns((new[]
            {
                new ProductDto {Id = 1, Name = "P1", Category = "Apples"},
                new ProductDto {Id = 2, Name = "P2", Category = "Apples"},
                new ProductDto {Id = 3, Name = "P3", Category = "Plums"},
                new ProductDto {Id = 4, Name = "P4", Category = "Oranges"},
            }).AsQueryable());

            var target = new NavigationMenuViewComponent(mock.Object);

            //Act
            string[] results = ((IEnumerable<string>) (target.Invoke()
                as ViewViewComponentResult)?.ViewData.Model)?.ToArray();

            //Assert
            Assert.True(Enumerable.SequenceEqual(new[] {"Apples", "Oranges", "Plums"}, results));
        }

        [Fact]
        public void Indicates_Selected_Category()
        {
            //Arrange
            const string categoryToSelect = "Apples";
            var mock = new Mock<IProductService>();
            mock.Setup(service => service.GetAll()).Returns((new[]
            {
                new ProductDto {Id = 1, Name = "P1", Category = "Apples"},
                new ProductDto {Id = 4, Name = "P2", Category = "Oranges"}
            }).AsQueryable());

            var target = new NavigationMenuViewComponent(mock.Object)
            {
                ViewComponentContext = new ViewComponentContext
                {
                    ViewContext = new ViewContext {RouteData = new RouteData()}
                }
            };
            target.RouteData.Values["category"] = categoryToSelect;

            //Act
            string result = (string) (target.Invoke() as ViewViewComponentResult)?.ViewData["SelectedCategory"];

            //Asset
            Assert.Equal(categoryToSelect, result);
        }
    }
}