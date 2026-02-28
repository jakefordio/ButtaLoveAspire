using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class ProductImage
{
    [Key]
    public int Id { get; set; }

    [MaxLength(2048)]
    public required string Url { get; set; }

    public required int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
}