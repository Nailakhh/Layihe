using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "UserComments",
                newName: "Text");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LikedUserIds",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "ParentCommentId",
                table: "UserComments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "UserComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserAvatarUrl",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Mechanics",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserCommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentLikes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentLikes_UserComments_UserCommentId",
                        column: x => x.UserCommentId,
                        principalTable: "UserComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_ParentCommentId",
                table: "UserComments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_AppUserId",
                table: "CommentLikes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentLikes_UserCommentId",
                table: "CommentLikes",
                column: "UserCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_UserComments_ParentCommentId",
                table: "UserComments",
                column: "ParentCommentId",
                principalTable: "UserComments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_UserComments_ParentCommentId",
                table: "UserComments");

            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_ParentCommentId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "LikedUserIds",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "UserAvatarUrl",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Mechanics");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "UserComments",
                newName: "Content");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
