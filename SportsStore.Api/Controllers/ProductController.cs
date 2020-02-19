using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts(
            [FromQuery(Name = "_page")] int page, 
            [FromQuery(Name = "_limit")] int limit,
            [FromQuery] string category,
            [FromQuery(Name = "q")] string searchQuery)
        {
            if (page == 0 || limit == 0)
            {
                return Ok(category == null ? _productService.GetAll() : _productService.GetAll(category));
            }
            
            IList<ProductDto> productsPaged = _productService.GetPaged(page, limit, category, searchQuery);

            Response.Headers.Add("X-Total-Count",
                category != null || searchQuery != null 
                    ? productsPaged.Count().ToString() : _productService.Count().ToString());

            return Ok(productsPaged);
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
    }
}
