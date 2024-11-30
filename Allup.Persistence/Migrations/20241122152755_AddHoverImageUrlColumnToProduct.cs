using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allup.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHoverImageUrlColumnToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HoverImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoverImageUrl",
                table: "Products");
        }
    }
}
