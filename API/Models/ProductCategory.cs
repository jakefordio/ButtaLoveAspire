using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; } = [];
        public ICollection<ProductImage> ProductImages { get; set; } = [];
    }
}