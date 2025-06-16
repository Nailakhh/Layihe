using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MercService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class usta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_SubModelProblems_ModelProblemId",
                table: "UserComments");

            migrationBuilder.AlterColumn<int>(
                name: "ModelProblemId",
                table: "UserComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MechanicId",
                table: "UserComments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ExperienceYear",
                table: "Mechanics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_MechanicId",
                table: "UserComments",
                column: "MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Mechanics_MechanicId",
                table: "UserComments",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_SubModelProblems_ModelProblemId",
                table: "UserComments",
                column: "ModelProblemId",
                principalTable: "SubModelProblems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Mechanics_MechanicId",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_SubModelProblems_ModelProblemId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_MechanicId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "MechanicId",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "ExperienceYear",
                table: "Mechanics");

            migrationBuilder.AlterColumn<int>(
                name: "ModelProblemId",
                table: "UserComments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Mechanics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_SubModelProblems_ModelProblemId",
                table: "UserComments",
                column: "ModelProblemId",
                principalTable: "SubModelProblems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
