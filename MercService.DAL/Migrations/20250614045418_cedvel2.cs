using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class cedvel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Mechanics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
