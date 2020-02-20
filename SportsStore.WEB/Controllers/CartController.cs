using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.WEB.Models;
using SportsStore.WEB.Models.ViewModels;
using System.Linq;

namespace SportsStore.WEB.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly Cart _cart;

        public CartController(IProductService productService, Cart cart)
        {
            _productService = productService;
            _cart = cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart([FromForm(Name = "Id")] int productId, string returnUrl)
        {
            ProductDto product = _productService.GetById(productId);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart([FromForm(Name = "Id")] int productId, string returnUrl)
        {
            ProductDto product = _productService.GetById(productId);

            if (product != null)
            {
                _cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}