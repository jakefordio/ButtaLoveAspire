using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Page
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public required string Title { get; set; }

        [MaxLength(200)]
        public required string Slug { get; set; }

        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public required string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public AppUser Author { get; set; } = null!;

        public ICollection<ContentBlock> ContentBlocks { get; set; } = new List<ContentBlock>();
    }
}