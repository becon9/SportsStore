using System.Collections.Generic;
using SportsStore.BLL.DTO;

namespace SportsStore.Api.Models
{
    public class OrderCreationRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public ICollection<CartLineDto> CartLines { get; set; }
        public bool GiftWrap { get; set; }
    }
}