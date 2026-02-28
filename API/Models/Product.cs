using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public double Weight { get; set; }
        public int StockQuantity { get; set; }

        public required int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory Category { get; set; } = null!;

        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    }
}