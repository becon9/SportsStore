using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.Interfaces;
using System.Linq;


namespace SportsStore.WEB.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public NavigationMenuViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_productService.GetAll()
                .Select(p => p.Category)
                .Distinct()
                .OrderBy(p => p));
        }
    }
}