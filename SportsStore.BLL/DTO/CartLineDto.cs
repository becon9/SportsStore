namespace SportsStore.BLL.DTO
{
    public class CartLineDto
    {
        public int CartLineId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
