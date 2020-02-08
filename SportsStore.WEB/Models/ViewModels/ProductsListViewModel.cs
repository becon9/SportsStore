using System.Collections.Generic;
using SportsStore.BLL.DTO;

namespace SportsStore.WEB.Models.ViewModels
{
    public class ProductsListViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}