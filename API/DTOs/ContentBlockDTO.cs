using System.ComponentModel.DataAnnotations;
using API.Validators;

namespace API.DTOs
{
    public record CreateContentBlockDto(
        string? Title,
        [Required]
        string Type,
        [Required]
        [ValidHtml]
        string HtmlContent,
        [Required]
        int OrderOnPage,
        [Required]
        int PageId,
        [Required]
        string AuthorId
    )
    {
        public DateTime CreatedAt { get; internal set; }
    }
}