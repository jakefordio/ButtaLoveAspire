using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    BirthMonth = table.Column<int>(type: "integer", nullable: false),
                    BirthDay = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Tax = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingCost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    StripePaymentIntentId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    OrderStatus = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContentBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HtmlContent = table.Column<string>(type: "text", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    PageId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentBlocks_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContentBlocks_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShoppingCartId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PriceAtPurchase = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Bath Bomb" },
                    { 2, null, "Bath Salt" },
                    { 3, null, "Body Butta" },
                    { 4, null, "Body Lotion" },
                    { 5, null, "Body Milk" },
                    { 6, null, "Body Oil" },
                    { 7, null, "Body Scrub" },
                    { 8, null, "Body Soak" },
                    { 9, null, "Soap" },
                    { 10, null, "Truffle" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "ProductCategoryId", "StockQuantity", "Weight" },
                values: new object[,]
                {
                    { 1, "Handcrafted Bath Bomb for the ButtaLove collection.", "Bath Bomb Variant 1", 16.00m, 1, 100, 0.5 },
                    { 2, "Handcrafted Bath Bomb for the ButtaLove collection.", "Bath Bomb Variant 2", 17.00m, 1, 100, 0.5 },
                    { 3, "Handcrafted Bath Bomb for the ButtaLove collection.", "Bath Bomb Variant 3", 18.00m, 1, 100, 0.5 },
                    { 4, "Handcrafted Bath Bomb for the ButtaLove collection.", "Bath Bomb Variant 4", 19.00m, 1, 100, 0.5 },
                    { 5, "Handcrafted Bath Bomb for the ButtaLove collection.", "Bath Bomb Variant 5", 20.00m, 1, 100, 0.5 },
                    { 6, "Handcrafted Bath Salt for the ButtaLove collection.", "Bath Salt Variant 1", 16.00m, 2, 100, 0.5 },
                    { 7, "Handcrafted Bath Salt for the ButtaLove collection.", "Bath Salt Variant 2", 17.00m, 2, 100, 0.5 },
                    { 8, "Handcrafted Bath Salt for the ButtaLove collection.", "Bath Salt Variant 3", 18.00m, 2, 100, 0.5 },
                    { 9, "Handcrafted Bath Salt for the ButtaLove collection.", "Bath Salt Variant 4", 19.00m, 2, 100, 0.5 },
                    { 10, "Handcrafted Bath Salt for the ButtaLove collection.", "Bath Salt Variant 5", 20.00m, 2, 100, 0.5 },
                    { 11, "Handcrafted Body Butta for the ButtaLove collection.", "Body Butta Variant 1", 16.00m, 3, 100, 0.5 },
                    { 12, "Handcrafted Body Butta for the ButtaLove collection.", "Body Butta Variant 2", 17.00m, 3, 100, 0.5 },
                    { 13, "Handcrafted Body Butta for the ButtaLove collection.", "Body Butta Variant 3", 18.00m, 3, 100, 0.5 },
                    { 14, "Handcrafted Body Butta for the ButtaLove collection.", "Body Butta Variant 4", 19.00m, 3, 100, 0.5 },
                    { 15, "Handcrafted Body Butta for the ButtaLove collection.", "Body Butta Variant 5", 20.00m, 3, 100, 0.5 },
                    { 16, "Handcrafted Body Lotion for the ButtaLove collection.", "Body Lotion Variant 1", 16.00m, 4, 100, 0.5 },
                    { 17, "Handcrafted Body Lotion for the ButtaLove collection.", "Body Lotion Variant 2", 17.00m, 4, 100, 0.5 },
                    { 18, "Handcrafted Body Lotion for the ButtaLove collection.", "Body Lotion Variant 3", 18.00m, 4, 100, 0.5 },
                    { 19, "Handcrafted Body Lotion for the ButtaLove collection.", "Body Lotion Variant 4", 19.00m, 4, 100, 0.5 },
                    { 20, "Handcrafted Body Lotion for the ButtaLove collection.", "Body Lotion Variant 5", 20.00m, 4, 100, 0.5 },
                    { 21, "Handcrafted Body Milk for the ButtaLove collection.", "Body Milk Variant 1", 16.00m, 5, 100, 0.5 },
                    { 22, "Handcrafted Body Milk for the ButtaLove collection.", "Body Milk Variant 2", 17.00m, 5, 100, 0.5 },
                    { 23, "Handcrafted Body Milk for the ButtaLove collection.", "Body Milk Variant 3", 18.00m, 5, 100, 0.5 },
                    { 24, "Handcrafted Body Milk for the ButtaLove collection.", "Body Milk Variant 4", 19.00m, 5, 100, 0.5 },
                    { 25, "Handcrafted Body Milk for the ButtaLove collection.", "Body Milk Variant 5", 20.00m, 5, 100, 0.5 },
                    { 26, "Handcrafted Body Oil for the ButtaLove collection.", "Body Oil Variant 1", 16.00m, 6, 100, 0.5 },
                    { 27, "Handcrafted Body Oil for the ButtaLove collection.", "Body Oil Variant 2", 17.00m, 6, 100, 0.5 },
                    { 28, "Handcrafted Body Oil for the ButtaLove collection.", "Body Oil Variant 3", 18.00m, 6, 100, 0.5 },
                    { 29, "Handcrafted Body Oil for the ButtaLove collection.", "Body Oil Variant 4", 19.00m, 6, 100, 0.5 },
                    { 30, "Handcrafted Body Oil for the ButtaLove collection.", "Body Oil Variant 5", 20.00m, 6, 100, 0.5 },
                    { 31, "Handcrafted Body Scrub for the ButtaLove collection.", "Body Scrub Variant 1", 16.00m, 7, 100, 0.5 },
                    { 32, "Handcrafted Body Scrub for the ButtaLove collection.", "Body Scrub Variant 2", 17.00m, 7, 100, 0.5 },
                    { 33, "Handcrafted Body Scrub for the ButtaLove collection.", "Body Scrub Variant 3", 18.00m, 7, 100, 0.5 },
                    { 34, "Handcrafted Body Scrub for the ButtaLove collection.", "Body Scrub Variant 4", 19.00m, 7, 100, 0.5 },
                    { 35, "Handcrafted Body Scrub for the ButtaLove collection.", "Body Scrub Variant 5", 20.00m, 7, 100, 0.5 },
                    { 36, "Handcrafted Body Soak for the ButtaLove collection.", "Body Soak Variant 1", 16.00m, 8, 100, 0.5 },
                    { 37, "Handcrafted Body Soak for the ButtaLove collection.", "Body Soak Variant 2", 17.00m, 8, 100, 0.5 },
                    { 38, "Handcrafted Body Soak for the ButtaLove collection.", "Body Soak Variant 3", 18.00m, 8, 100, 0.5 },
                    { 39, "Handcrafted Body Soak for the ButtaLove collection.", "Body Soak Variant 4", 19.00m, 8, 100, 0.5 },
                    { 40, "Handcrafted Body Soak for the ButtaLove collection.", "Body Soak Variant 5", 20.00m, 8, 100, 0.5 },
                    { 41, "Handcrafted Soap for the ButtaLove collection.", "Soap Variant 1", 16.00m, 9, 100, 0.5 },
                    { 42, "Handcrafted Soap for the ButtaLove collection.", "Soap Variant 2", 17.00m, 9, 100, 0.5 },
                    { 43, "Handcrafted Soap for the ButtaLove collection.", "Soap Variant 3", 18.00m, 9, 100, 0.5 },
                    { 44, "Handcrafted Soap for the ButtaLove collection.", "Soap Variant 4", 19.00m, 9, 100, 0.5 },
                    { 45, "Handcrafted Soap for the ButtaLove collection.", "Soap Variant 5", 20.00m, 9, 100, 0.5 },
                    { 46, "Handcrafted Truffle for the ButtaLove collection.", "Truffle Variant 1", 16.00m, 10, 100, 0.5 },
                    { 47, "Handcrafted Truffle for the ButtaLove collection.", "Truffle Variant 2", 17.00m, 10, 100, 0.5 },
                    { 48, "Handcrafted Truffle for the ButtaLove collection.", "Truffle Variant 3", 18.00m, 10, 100, 0.5 },
                    { 49, "Handcrafted Truffle for the ButtaLove collection.", "Truffle Variant 4", 19.00m, 10, 100, 0.5 },
                    { 50, "Handcrafted Truffle for the ButtaLove collection.", "Truffle Variant 5", 20.00m, 10, 100, 0.5 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ProductCategoryId", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, null, 1, "/API/Images/Products/bodybutta.jpg" },
                    { 2, null, 1, "/API/Images/Products/bodybutta.jpg" },
                    { 3, null, 1, "/API/Images/Products/bodybutta.jpg" },
                    { 4, null, 1, "/API/Images/Products/bodybutta.jpg" },
                    { 5, null, 1, "/API/Images/Products/bodybutta.jpg" },
                    { 6, null, 2, "/API/Images/Products/bodybutta.jpg" },
                    { 7, null, 2, "/API/Images/Products/bodybutta.jpg" },
                    { 8, null, 2, "/API/Images/Products/bodybutta.jpg" },
                    { 9, null, 2, "/API/Images/Products/bodybutta.jpg" },
                    { 10, null, 2, "/API/Images/Products/bodybutta.jpg" },
                    { 11, null, 3, "/API/Images/Products/bodybutta.jpg" },
                    { 12, null, 3, "/API/Images/Products/bodybutta.jpg" },
                    { 13, null, 3, "/API/Images/Products/bodybutta.jpg" },
                    { 14, null, 3, "/API/Images/Products/bodybutta.jpg" },
                    { 15, null, 3, "/API/Images/Products/bodybutta.jpg" },
                    { 16, null, 4, "/API/Images/Products/bodybutta.jpg" },
                    { 17, null, 4, "/API/Images/Products/bodybutta.jpg" },
                    { 18, null, 4, "/API/Images/Products/bodybutta.jpg" },
                    { 19, null, 4, "/API/Images/Products/bodybutta.jpg" },
                    { 20, null, 4, "/API/Images/Products/bodybutta.jpg" },
                    { 21, null, 5, "/API/Images/Products/bodybutta.jpg" },
                    { 22, null, 5, "/API/Images/Products/bodybutta.jpg" },
                    { 23, null, 5, "/API/Images/Products/bodybutta.jpg" },
                    { 24, null, 5, "/API/Images/Products/bodybutta.jpg" },
                    { 25, null, 5, "/API/Images/Products/bodybutta.jpg" },
                    { 26, null, 6, "/API/Images/Products/bodybutta.jpg" },
                    { 27, null, 6, "/API/Images/Products/bodybutta.jpg" },
                    { 28, null, 6, "/API/Images/Products/bodybutta.jpg" },
                    { 29, null, 6, "/API/Images/Products/bodybutta.jpg" },
                    { 30, null, 6, "/API/Images/Products/bodybutta.jpg" },
                    { 31, null, 7, "/API/Images/Products/bodybutta.jpg" },
                    { 32, null, 7, "/API/Images/Products/bodybutta.jpg" },
                    { 33, null, 7, "/API/Images/Products/bodybutta.jpg" },
                    { 34, null, 7, "/API/Images/Products/bodybutta.jpg" },
                    { 35, null, 7, "/API/Images/Products/bodybutta.jpg" },
                    { 36, null, 8, "/API/Images/Products/bodybutta.jpg" },
                    { 37, null, 8, "/API/Images/Products/bodybutta.jpg" },
                    { 38, null, 8, "/API/Images/Products/bodybutta.jpg" },
                    { 39, null, 8, "/API/Images/Products/bodybutta.jpg" },
                    { 40, null, 8, "/API/Images/Products/bodybutta.jpg" },
                    { 41, null, 9, "/API/Images/Products/bodybutta.jpg" },
                    { 42, null, 9, "/API/Images/Products/bodybutta.jpg" },
                    { 43, null, 9, "/API/Images/Products/bodybutta.jpg" },
                    { 44, null, 9, "/API/Images/Products/bodybutta.jpg" },
                    { 45, null, 9, "/API/Images/Products/bodybutta.jpg" },
                    { 46, null, 10, "/API/Images/Products/bodybutta.jpg" },
                    { 47, null, 10, "/API/Images/Products/bodybutta.jpg" },
                    { 48, null, 10, "/API/Images/Products/bodybutta.jpg" },
                    { 49, null, 10, "/API/Images/Products/bodybutta.jpg" },
                    { 50, null, 10, "/API/Images/Products/bodybutta.jpg" },
                    { 51, null, 11, "/API/Images/Products/bodybutta.jpg" },
                    { 52, null, 11, "/API/Images/Products/bodybutta.jpg" },
                    { 53, null, 11, "/API/Images/Products/bodybutta.jpg" },
                    { 54, null, 11, "/API/Images/Products/bodybutta.jpg" },
                    { 55, null, 11, "/API/Images/Products/bodybutta.jpg" },
                    { 56, null, 12, "/API/Images/Products/bodybutta.jpg" },
                    { 57, null, 12, "/API/Images/Products/bodybutta.jpg" },
                    { 58, null, 12, "/API/Images/Products/bodybutta.jpg" },
                    { 59, null, 12, "/API/Images/Products/bodybutta.jpg" },
                    { 60, null, 12, "/API/Images/Products/bodybutta.jpg" },
                    { 61, null, 13, "/API/Images/Products/bodybutta.jpg" },
                    { 62, null, 13, "/API/Images/Products/bodybutta.jpg" },
                    { 63, null, 13, "/API/Images/Products/bodybutta.jpg" },
                    { 64, null, 13, "/API/Images/Products/bodybutta.jpg" },
                    { 65, null, 13, "/API/Images/Products/bodybutta.jpg" },
                    { 66, null, 14, "/API/Images/Products/bodybutta.jpg" },
                    { 67, null, 14, "/API/Images/Products/bodybutta.jpg" },
                    { 68, null, 14, "/API/Images/Products/bodybutta.jpg" },
                    { 69, null, 14, "/API/Images/Products/bodybutta.jpg" },
                    { 70, null, 14, "/API/Images/Products/bodybutta.jpg" },
                    { 71, null, 15, "/API/Images/Products/bodybutta.jpg" },
                    { 72, null, 15, "/API/Images/Products/bodybutta.jpg" },
                    { 73, null, 15, "/API/Images/Products/bodybutta.jpg" },
                    { 74, null, 15, "/API/Images/Products/bodybutta.jpg" },
                    { 75, null, 15, "/API/Images/Products/bodybutta.jpg" },
                    { 76, null, 16, "/API/Images/Products/bodybutta.jpg" },
                    { 77, null, 16, "/API/Images/Products/bodybutta.jpg" },
                    { 78, null, 16, "/API/Images/Products/bodybutta.jpg" },
                    { 79, null, 16, "/API/Images/Products/bodybutta.jpg" },
                    { 80, null, 16, "/API/Images/Products/bodybutta.jpg" },
                    { 81, null, 17, "/API/Images/Products/bodybutta.jpg" },
                    { 82, null, 17, "/API/Images/Products/bodybutta.jpg" },
                    { 83, null, 17, "/API/Images/Products/bodybutta.jpg" },
                    { 84, null, 17, "/API/Images/Products/bodybutta.jpg" },
                    { 85, null, 17, "/API/Images/Products/bodybutta.jpg" },
                    { 86, null, 18, "/API/Images/Products/bodybutta.jpg" },
                    { 87, null, 18, "/API/Images/Products/bodybutta.jpg" },
                    { 88, null, 18, "/API/Images/Products/bodybutta.jpg" },
                    { 89, null, 18, "/API/Images/Products/bodybutta.jpg" },
                    { 90, null, 18, "/API/Images/Products/bodybutta.jpg" },
                    { 91, null, 19, "/API/Images/Products/bodybutta.jpg" },
                    { 92, null, 19, "/API/Images/Products/bodybutta.jpg" },
                    { 93, null, 19, "/API/Images/Products/bodybutta.jpg" },
                    { 94, null, 19, "/API/Images/Products/bodybutta.jpg" },
                    { 95, null, 19, "/API/Images/Products/bodybutta.jpg" },
                    { 96, null, 20, "/API/Images/Products/bodybutta.jpg" },
                    { 97, null, 20, "/API/Images/Products/bodybutta.jpg" },
                    { 98, null, 20, "/API/Images/Products/bodybutta.jpg" },
                    { 99, null, 20, "/API/Images/Products/bodybutta.jpg" },
                    { 100, null, 20, "/API/Images/Products/bodybutta.jpg" },
                    { 101, null, 21, "/API/Images/Products/bodybutta.jpg" },
                    { 102, null, 21, "/API/Images/Products/bodybutta.jpg" },
                    { 103, null, 21, "/API/Images/Products/bodybutta.jpg" },
                    { 104, null, 21, "/API/Images/Products/bodybutta.jpg" },
                    { 105, null, 21, "/API/Images/Products/bodybutta.jpg" },
                    { 106, null, 22, "/API/Images/Products/bodybutta.jpg" },
                    { 107, null, 22, "/API/Images/Products/bodybutta.jpg" },
                    { 108, null, 22, "/API/Images/Products/bodybutta.jpg" },
                    { 109, null, 22, "/API/Images/Products/bodybutta.jpg" },
                    { 110, null, 22, "/API/Images/Products/bodybutta.jpg" },
                    { 111, null, 23, "/API/Images/Products/bodybutta.jpg" },
                    { 112, null, 23, "/API/Images/Products/bodybutta.jpg" },
                    { 113, null, 23, "/API/Images/Products/bodybutta.jpg" },
                    { 114, null, 23, "/API/Images/Products/bodybutta.jpg" },
                    { 115, null, 23, "/API/Images/Products/bodybutta.jpg" },
                    { 116, null, 24, "/API/Images/Products/bodybutta.jpg" },
                    { 117, null, 24, "/API/Images/Products/bodybutta.jpg" },
                    { 118, null, 24, "/API/Images/Products/bodybutta.jpg" },
                    { 119, null, 24, "/API/Images/Products/bodybutta.jpg" },
                    { 120, null, 24, "/API/Images/Products/bodybutta.jpg" },
                    { 121, null, 25, "/API/Images/Products/bodybutta.jpg" },
                    { 122, null, 25, "/API/Images/Products/bodybutta.jpg" },
                    { 123, null, 25, "/API/Images/Products/bodybutta.jpg" },
                    { 124, null, 25, "/API/Images/Products/bodybutta.jpg" },
                    { 125, null, 25, "/API/Images/Products/bodybutta.jpg" },
                    { 126, null, 26, "/API/Images/Products/bodybutta.jpg" },
                    { 127, null, 26, "/API/Images/Products/bodybutta.jpg" },
                    { 128, null, 26, "/API/Images/Products/bodybutta.jpg" },
                    { 129, null, 26, "/API/Images/Products/bodybutta.jpg" },
                    { 130, null, 26, "/API/Images/Products/bodybutta.jpg" },
                    { 131, null, 27, "/API/Images/Products/bodybutta.jpg" },
                    { 132, null, 27, "/API/Images/Products/bodybutta.jpg" },
                    { 133, null, 27, "/API/Images/Products/bodybutta.jpg" },
                    { 134, null, 27, "/API/Images/Products/bodybutta.jpg" },
                    { 135, null, 27, "/API/Images/Products/bodybutta.jpg" },
                    { 136, null, 28, "/API/Images/Products/bodybutta.jpg" },
                    { 137, null, 28, "/API/Images/Products/bodybutta.jpg" },
                    { 138, null, 28, "/API/Images/Products/bodybutta.jpg" },
                    { 139, null, 28, "/API/Images/Products/bodybutta.jpg" },
                    { 140, null, 28, "/API/Images/Products/bodybutta.jpg" },
                    { 141, null, 29, "/API/Images/Products/bodybutta.jpg" },
                    { 142, null, 29, "/API/Images/Products/bodybutta.jpg" },
                    { 143, null, 29, "/API/Images/Products/bodybutta.jpg" },
                    { 144, null, 29, "/API/Images/Products/bodybutta.jpg" },
                    { 145, null, 29, "/API/Images/Products/bodybutta.jpg" },
                    { 146, null, 30, "/API/Images/Products/bodybutta.jpg" },
                    { 147, null, 30, "/API/Images/Products/bodybutta.jpg" },
                    { 148, null, 30, "/API/Images/Products/bodybutta.jpg" },
                    { 149, null, 30, "/API/Images/Products/bodybutta.jpg" },
                    { 150, null, 30, "/API/Images/Products/bodybutta.jpg" },
                    { 151, null, 31, "/API/Images/Products/bodybutta.jpg" },
                    { 152, null, 31, "/API/Images/Products/bodybutta.jpg" },
                    { 153, null, 31, "/API/Images/Products/bodybutta.jpg" },
                    { 154, null, 31, "/API/Images/Products/bodybutta.jpg" },
                    { 155, null, 31, "/API/Images/Products/bodybutta.jpg" },
                    { 156, null, 32, "/API/Images/Products/bodybutta.jpg" },
                    { 157, null, 32, "/API/Images/Products/bodybutta.jpg" },
                    { 158, null, 32, "/API/Images/Products/bodybutta.jpg" },
                    { 159, null, 32, "/API/Images/Products/bodybutta.jpg" },
                    { 160, null, 32, "/API/Images/Products/bodybutta.jpg" },
                    { 161, null, 33, "/API/Images/Products/bodybutta.jpg" },
                    { 162, null, 33, "/API/Images/Products/bodybutta.jpg" },
                    { 163, null, 33, "/API/Images/Products/bodybutta.jpg" },
                    { 164, null, 33, "/API/Images/Products/bodybutta.jpg" },
                    { 165, null, 33, "/API/Images/Products/bodybutta.jpg" },
                    { 166, null, 34, "/API/Images/Products/bodybutta.jpg" },
                    { 167, null, 34, "/API/Images/Products/bodybutta.jpg" },
                    { 168, null, 34, "/API/Images/Products/bodybutta.jpg" },
                    { 169, null, 34, "/API/Images/Products/bodybutta.jpg" },
                    { 170, null, 34, "/API/Images/Products/bodybutta.jpg" },
                    { 171, null, 35, "/API/Images/Products/bodybutta.jpg" },
                    { 172, null, 35, "/API/Images/Products/bodybutta.jpg" },
                    { 173, null, 35, "/API/Images/Products/bodybutta.jpg" },
                    { 174, null, 35, "/API/Images/Products/bodybutta.jpg" },
                    { 175, null, 35, "/API/Images/Products/bodybutta.jpg" },
                    { 176, null, 36, "/API/Images/Products/bodybutta.jpg" },
                    { 177, null, 36, "/API/Images/Products/bodybutta.jpg" },
                    { 178, null, 36, "/API/Images/Products/bodybutta.jpg" },
                    { 179, null, 36, "/API/Images/Products/bodybutta.jpg" },
                    { 180, null, 36, "/API/Images/Products/bodybutta.jpg" },
                    { 181, null, 37, "/API/Images/Products/bodybutta.jpg" },
                    { 182, null, 37, "/API/Images/Products/bodybutta.jpg" },
                    { 183, null, 37, "/API/Images/Products/bodybutta.jpg" },
                    { 184, null, 37, "/API/Images/Products/bodybutta.jpg" },
                    { 185, null, 37, "/API/Images/Products/bodybutta.jpg" },
                    { 186, null, 38, "/API/Images/Products/bodybutta.jpg" },
                    { 187, null, 38, "/API/Images/Products/bodybutta.jpg" },
                    { 188, null, 38, "/API/Images/Products/bodybutta.jpg" },
                    { 189, null, 38, "/API/Images/Products/bodybutta.jpg" },
                    { 190, null, 38, "/API/Images/Products/bodybutta.jpg" },
                    { 191, null, 39, "/API/Images/Products/bodybutta.jpg" },
                    { 192, null, 39, "/API/Images/Products/bodybutta.jpg" },
                    { 193, null, 39, "/API/Images/Products/bodybutta.jpg" },
                    { 194, null, 39, "/API/Images/Products/bodybutta.jpg" },
                    { 195, null, 39, "/API/Images/Products/bodybutta.jpg" },
                    { 196, null, 40, "/API/Images/Products/bodybutta.jpg" },
                    { 197, null, 40, "/API/Images/Products/bodybutta.jpg" },
                    { 198, null, 40, "/API/Images/Products/bodybutta.jpg" },
                    { 199, null, 40, "/API/Images/Products/bodybutta.jpg" },
                    { 200, null, 40, "/API/Images/Products/bodybutta.jpg" },
                    { 201, null, 41, "/API/Images/Products/bodybutta.jpg" },
                    { 202, null, 41, "/API/Images/Products/bodybutta.jpg" },
                    { 203, null, 41, "/API/Images/Products/bodybutta.jpg" },
                    { 204, null, 41, "/API/Images/Products/bodybutta.jpg" },
                    { 205, null, 41, "/API/Images/Products/bodybutta.jpg" },
                    { 206, null, 42, "/API/Images/Products/bodybutta.jpg" },
                    { 207, null, 42, "/API/Images/Products/bodybutta.jpg" },
                    { 208, null, 42, "/API/Images/Products/bodybutta.jpg" },
                    { 209, null, 42, "/API/Images/Products/bodybutta.jpg" },
                    { 210, null, 42, "/API/Images/Products/bodybutta.jpg" },
                    { 211, null, 43, "/API/Images/Products/bodybutta.jpg" },
                    { 212, null, 43, "/API/Images/Products/bodybutta.jpg" },
                    { 213, null, 43, "/API/Images/Products/bodybutta.jpg" },
                    { 214, null, 43, "/API/Images/Products/bodybutta.jpg" },
                    { 215, null, 43, "/API/Images/Products/bodybutta.jpg" },
                    { 216, null, 44, "/API/Images/Products/bodybutta.jpg" },
                    { 217, null, 44, "/API/Images/Products/bodybutta.jpg" },
                    { 218, null, 44, "/API/Images/Products/bodybutta.jpg" },
                    { 219, null, 44, "/API/Images/Products/bodybutta.jpg" },
                    { 220, null, 44, "/API/Images/Products/bodybutta.jpg" },
                    { 221, null, 45, "/API/Images/Products/bodybutta.jpg" },
                    { 222, null, 45, "/API/Images/Products/bodybutta.jpg" },
                    { 223, null, 45, "/API/Images/Products/bodybutta.jpg" },
                    { 224, null, 45, "/API/Images/Products/bodybutta.jpg" },
                    { 225, null, 45, "/API/Images/Products/bodybutta.jpg" },
                    { 226, null, 46, "/API/Images/Products/bodybutta.jpg" },
                    { 227, null, 46, "/API/Images/Products/bodybutta.jpg" },
                    { 228, null, 46, "/API/Images/Products/bodybutta.jpg" },
                    { 229, null, 46, "/API/Images/Products/bodybutta.jpg" },
                    { 230, null, 46, "/API/Images/Products/bodybutta.jpg" },
                    { 231, null, 47, "/API/Images/Products/bodybutta.jpg" },
                    { 232, null, 47, "/API/Images/Products/bodybutta.jpg" },
                    { 233, null, 47, "/API/Images/Products/bodybutta.jpg" },
                    { 234, null, 47, "/API/Images/Products/bodybutta.jpg" },
                    { 235, null, 47, "/API/Images/Products/bodybutta.jpg" },
                    { 236, null, 48, "/API/Images/Products/bodybutta.jpg" },
                    { 237, null, 48, "/API/Images/Products/bodybutta.jpg" },
                    { 238, null, 48, "/API/Images/Products/bodybutta.jpg" },
                    { 239, null, 48, "/API/Images/Products/bodybutta.jpg" },
                    { 240, null, 48, "/API/Images/Products/bodybutta.jpg" },
                    { 241, null, 49, "/API/Images/Products/bodybutta.jpg" },
                    { 242, null, 49, "/API/Images/Products/bodybutta.jpg" },
                    { 243, null, 49, "/API/Images/Products/bodybutta.jpg" },
                    { 244, null, 49, "/API/Images/Products/bodybutta.jpg" },
                    { 245, null, 49, "/API/Images/Products/bodybutta.jpg" },
                    { 246, null, 50, "/API/Images/Products/bodybutta.jpg" },
                    { 247, null, 50, "/API/Images/Products/bodybutta.jpg" },
                    { 248, null, 50, "/API/Images/Products/bodybutta.jpg" },
                    { 249, null, 50, "/API/Images/Products/bodybutta.jpg" },
                    { 250, null, 50, "/API/Images/Products/bodybutta.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Birthday",
                table: "AspNetUsers",
                columns: new[] { "BirthMonth", "BirthDay" });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ShoppingCartId",
                table: "CartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlocks_AuthorId",
                table: "ContentBlocks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlocks_PageId_SortOrder",
                table: "ContentBlocks",
                columns: new[] { "PageId", "SortOrder" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StripePaymentIntentId",
                table: "Orders",
                column: "StripePaymentIntentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_AuthorId",
                table: "Pages",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_Slug",
                table: "Pages",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductCategoryId",
                table: "ProductImages",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_AppUserId",
                table: "ShoppingCarts",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ContentBlocks");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
