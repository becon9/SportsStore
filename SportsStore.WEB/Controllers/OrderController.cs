using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.WEB.Models;
using System.Linq;

namespace SportsStore.WEB.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly Cart _cart;

        public OrderController(IOrderService orderService, Cart cart)
        {
            _orderService = orderService;
            _cart = cart;
        }

        [Authorize]
        public ViewResult List()
        {
            return View(_orderService.GetNotShippedOrders());
        }

        [HttpPost]
        [Authorize]
        public IActionResult MarkShipped(int orderId)
        {
            _orderService.MarkShipped(orderId);

            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout()
        {
            return View(new OrderDto());
        }

        [HttpPost]
        public IActionResult Checkout(OrderDto order)
        {
            if (!_cart.Lines.Any())
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _orderService.AddProductToLine(order);
                return RedirectToAction(nameof(Completed));
            }

            return View(order);
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}