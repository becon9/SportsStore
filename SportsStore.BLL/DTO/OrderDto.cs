using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.BLL.DTO
{
    public class OrderDto
    {
        [BindNever]
        public int Id { get; set; }

        [BindNever]
        public ICollection<CartLineDto> Lines { get; set; }

        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter first address line")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }
        public string Zip { get; set; }
        public bool GiftWrap { get; set; }
    }
}