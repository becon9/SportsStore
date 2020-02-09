using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Interfaces;
using SportsStore.WEB.Models;

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
            return View(_orderService.Orders.Where(o => !o.Shipped));
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
                _orderService.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}