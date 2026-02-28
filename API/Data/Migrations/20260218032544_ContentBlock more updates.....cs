using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContentBlockmoreupdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SortOrder",
                table: "ContentBlocks",
                newName: "OrderOnPage");

            migrationBuilder.RenameIndex(
                name: "IX_ContentBlocks_PageId_SortOrder",
                table: "ContentBlocks",
                newName: "IX_ContentBlocks_PageId_OrderOnPage");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ContentBlocks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ContentBlocks",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ContentBlocks");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ContentBlocks");

            migrationBuilder.RenameColumn(
                name: "OrderOnPage",
                table: "ContentBlocks",
                newName: "SortOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ContentBlocks_PageId_OrderOnPage",
                table: "ContentBlocks",
                newName: "IX_ContentBlocks_PageId_SortOrder");
        }
    }
}
