using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ustaelave : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Certificates",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxPrice",
                table: "Mechanics",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinPrice",
                table: "Mechanics",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RepairAreas",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificates",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "MaxPrice",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "MinPrice",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "RepairAreas",
                table: "Mechanics");
        }
    }
}
