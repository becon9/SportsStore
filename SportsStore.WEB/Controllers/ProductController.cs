﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.BLL.DTO;
using SportsStore.BLL.Services.Interfaces;
using SportsStore.WEB.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public int PageSize { get; set; } = 4;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            IList<ProductDto> result = _productService.GetPaged(productPage, PageSize, category);
            return View(new ProductsListViewModel
            {
                Products = result,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? _productService.GetAll().Count() : result.Count()
                },
                CurrentCategory = category
            });
        }
    }
}