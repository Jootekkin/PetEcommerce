using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetEcommerce.Infrastrcure.Migrations
{
    /// <inheritdoc />
    public partial class URLMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Toys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Foods");
        }
    }
}
