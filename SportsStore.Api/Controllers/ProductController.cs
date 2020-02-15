using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;

namespace SportsStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public ProductDto GetById(int id)
        {
            ProductDto product = _productService.GetById(id);
            return product;
        }

        [HttpGet("categories")]
        public IEnumerable<string> GetCategories()
        {
            return _productService.GetCategories();
        }
    }
}
