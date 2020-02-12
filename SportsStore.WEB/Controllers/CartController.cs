using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Interfaces;
using SportsStore.WEB.Models;
using System.Linq;
using SportsStore.WEB.Models.ViewModels;

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

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            ProductDto product = _productService.GetAll()
                .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            ProductDto product = _productService.GetAll()
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                _cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}