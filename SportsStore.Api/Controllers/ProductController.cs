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
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            ProductDto product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpGet("categories")]
        public ActionResult<IEnumerable<string>> GetCategories()
        {
            return Ok(_productService.GetCategories());
        }

        [HttpGet]
        public ActionResult GetPage([FromQuery(Name = "_page")] int page, [FromQuery(Name = "_limit")] int limit,
            [FromQuery] string category)
        {
            
            return Ok();
        }
    }
}
