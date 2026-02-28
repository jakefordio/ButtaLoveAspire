using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }

        public required string AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser User { get; set; } = null!;

        public ICollection<CartItem> Items { get; set; } = [];

    }
}