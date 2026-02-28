using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ButtaLoveDbContext(DbContextOptions<ButtaLoveDbContext> options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ContentBlock> ContentBlocks { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // --- Relationships ---
            builder.Entity<AppUser>()
                .HasOne(u => u.ShoppingCart)
                .WithOne(c => c.User)
                .HasForeignKey<ShoppingCart>(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Page>()
                .HasOne(p => p.Author)
                .WithMany(u => u.AuthoredPages)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ContentBlock>()
                .HasOne(cb => cb.Author)
                .WithMany(u => u.AuthoredBlocks)
                .HasForeignKey(cb => cb.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ContentBlock>()
                .HasOne(cb => cb.Page)
                .WithMany(p => p.ContentBlocks)
                .HasForeignKey(cb => cb.PageId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // --- Indexes for Performance ---
            builder.Entity<AppUser>()
                .HasIndex(u => new { u.BirthMonth, u.BirthDay })
                .HasDatabaseName("IX_AppUser_Birthday");
            builder.Entity<Page>()
                .HasIndex(p => p.Slug)
                .IsUnique();
            builder.Entity<ContentBlock>()
                .HasIndex(cb => new { cb.PageId, cb.OrderOnPage });
            builder.Entity<Product>()
                .HasIndex(p => p.Name);
            builder.Entity<Order>()
                .HasIndex(o => o.AppUserId);
            builder.Entity<Order>()
                .HasIndex(o => o.StripePaymentIntentId);

            // --- Precision Configurations ---
            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
            builder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Subtotal).HasPrecision(18, 2);
                entity.Property(e => e.Tax).HasPrecision(18, 2);
                entity.Property(e => e.ShippingCost).HasPrecision(18, 2);
                entity.Property(e => e.Total).HasPrecision(18, 2);
            });
            builder.Entity<OrderItem>()
                .Property(oi => oi.PriceAtPurchase)
                .HasPrecision(18, 2);

            // --- Seed Data ---
            builder.Entity<ProductCategory>().HasData(
                new ProductCategory { Id = 1, Name = "Bath Bomb" },
                new ProductCategory { Id = 2, Name = "Bath Salt" },
                new ProductCategory { Id = 3, Name = "Body Butta" },
                new ProductCategory { Id = 4, Name = "Body Lotion" },
                new ProductCategory { Id = 5, Name = "Body Milk" },
                new ProductCategory { Id = 6, Name = "Body Oil" },
                new ProductCategory { Id = 7, Name = "Body Scrub" },
                new ProductCategory { Id = 8, Name = "Body Soak" },
                new ProductCategory { Id = 9, Name = "Soap" },
                new ProductCategory { Id = 10, Name = "Truffle" }
            );
            var products = new List<Product>();
            var productImages = new List<ProductImage>();
            string defaultImg = "/API/Images/Products/bodybutta.jpg";
            int imageIdCounter = 1;
            string[] categories = ["Bath Bomb", "Bath Salt", "Body Butta", "Body Lotion", "Body Milk", "Body Oil", "Body Scrub", "Body Soak", "Soap", "Truffle"
            ];
            for (int catId = 1; catId <= 10; catId++)
            {
                string catName = categories[catId - 1];
                for (int p = 1; p <= 5; p++)
                {
                    int productId = ((catId - 1) * 5) + p;
                    products.Add(new Product
                    {
                        Id = productId,
                        Name = $"{catName} Variant {p}",
                        Description = $"Handcrafted {catName} for the ButtaLove collection.",
                        Price = 15.00m + p,
                        Weight = 0.5,
                        StockQuantity = 100,
                        ProductCategoryId = catId
                    });

                    for (int img = 1; img <= 5; img++)
                    {
                        productImages.Add(new ProductImage
                        {
                            Id = imageIdCounter++,
                            ProductId = productId,
                            Url = defaultImg
                        });
                    }
                }
            }
            builder.Entity<Product>().HasData(products);
            builder.Entity<ProductImage>().HasData(productImages);
        }
    }
}