using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Validators;

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

namespace API.Models
{
    public class ContentBlock
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(50)]
        public required string Type { get; set; }

        [ValidHtml]
        public required string HtmlContent { get; set; }

        public required int OrderOnPage { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public required int PageId { get; set; }
        [ForeignKey("PageId")]
        public Page Page { get; set; } = null!;

        public required string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public AppUser Author { get; set; } = null!;
    }
}