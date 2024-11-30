using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Allup.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSellCountColumnToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SellCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellCount",
                table: "Products");
        }
    }
}
