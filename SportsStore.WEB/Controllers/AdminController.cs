using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Interfaces;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace SportsStore.WEB.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult Index()
        {
            return View(_productService.GetAll());
        }

        public ViewResult Create()
        {
            return View("Edit", new ProductDto());
        }

        public ViewResult Edit(int productId)
        {
            return View(_productService.GetAll()
                .FirstOrDefault(p => p.ProductId == productId));
        }

        [HttpPost]
        public IActionResult Edit(ProductDto product)
        {
            if (!ModelState.IsValid) return View(product);

            IFormFileCollection files = HttpContext.Request.Form.Files;

            if (files != null && files.Count > 0)
            {
                IFormFile file = files[0];
                product.Image.ContentType = file.ContentType;
                using var ms = new MemoryStream();
                file.CopyTo(ms);
                byte[] fileBytes = ms.ToArray();
                product.Image.Base64 = Convert.ToBase64String(fileBytes);
            }

            if (product.ProductId == 0)
            {
                _productService.Add(product);
            }
            else
            {
                _productService.Update(product);
            }
            
            TempData["message"] = $"{product.Name} has been saved";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {

            ProductDto deletedProduct = _productService.GetById(productId);
            
            if (deletedProduct != null)
            {
                _productService.Remove(deletedProduct);
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }

            return RedirectToAction("Index");
        }
    }
}
