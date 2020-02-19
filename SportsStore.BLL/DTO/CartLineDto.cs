namespace SportsStore.BLL.DTO
{
    public class CartLineDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
