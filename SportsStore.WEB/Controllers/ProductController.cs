using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Interfaces;
using SportsStore.WEB.Models.ViewModels;

namespace SportsStore.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public int PageSize { get; set; } = 4;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            List<ProductDto> result = _productService.ProductsWithImages
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
            return View(new ProductsListViewModel
            {
                Products = result,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? _productService.Products.Count() : result.Count()
                },
                CurrentCategory = category
            });
        }
    }
}