using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class clientuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "ClientReviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ClientReviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientReviews_AppUserId",
                table: "ClientReviews",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientReviews_AspNetUsers_AppUserId",
                table: "ClientReviews",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientReviews_AspNetUsers_AppUserId",
                table: "ClientReviews");

            migrationBuilder.DropIndex(
                name: "IX_ClientReviews_AppUserId",
                table: "ClientReviews");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ClientReviews");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "ClientReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
