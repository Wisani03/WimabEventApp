using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WimabEventApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGiftTypeToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GiftType",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiftType",
                table: "Products");
        }
    }
}
