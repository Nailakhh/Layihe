using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class cedvel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Mechanics",
                newName: "TwitterUrl");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Mechanics",
                newName: "InstagramUrl");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "UserComments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_AppUserId",
                table: "UserComments",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_AspNetUsers_AppUserId",
                table: "UserComments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_AspNetUsers_AppUserId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_AppUserId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Mechanics");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Mechanics");

            migrationBuilder.RenameColumn(
                name: "TwitterUrl",
                table: "Mechanics",
                newName: "Specialization");

            migrationBuilder.RenameColumn(
                name: "InstagramUrl",
                table: "Mechanics",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }
    }
}
