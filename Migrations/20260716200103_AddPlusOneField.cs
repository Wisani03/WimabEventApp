using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WimabEventApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPlusOneField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlusOneName",
                table: "Guests",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlusOneName",
                table: "Guests");
        }
    }
}
