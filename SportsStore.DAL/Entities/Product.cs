using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.DAL.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string Category { get; set; }

        public Image Image { get; set; }
    }
}