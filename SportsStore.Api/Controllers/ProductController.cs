using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using System.Collections.Generic;

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
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ProductDto product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            return Ok(_productService.GetCategories());
        }
    }
}
