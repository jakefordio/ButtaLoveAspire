using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

namespace API.Models
{
    public class AppUser : IdentityUser
    {
        public required int BirthMonth { get; set; }
        public required int BirthDay { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? State { get; set; }
        [MaxLength(20)]
        public string? ZipCode { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<Page> AuthoredPages { get; set; } = new List<Page>();
        public ICollection<ContentBlock> AuthoredBlocks { get; set; } = new List<ContentBlock>();
    }
}