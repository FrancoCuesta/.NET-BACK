using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class premio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PencaId",
                table: "Premios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Premios",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Predicsion",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "activa",
                table: "Penca",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Premios_PencaId",
                table: "Premios",
                column: "PencaId");

            migrationBuilder.CreateIndex(
                name: "IX_Premios_UserId",
                table: "Premios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Predicsion_UserId",
                table: "Predicsion",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Predicsion_AspNetUsers_UserId",
                table: "Predicsion",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Premios_AspNetUsers_UserId",
                table: "Premios",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Premios_Penca_PencaId",
                table: "Premios",
                column: "PencaId",
                principalTable: "Penca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Predicsion_AspNetUsers_UserId",
                table: "Predicsion");

            migrationBuilder.DropForeignKey(
                name: "FK_Premios_AspNetUsers_UserId",
                table: "Premios");

            migrationBuilder.DropForeignKey(
                name: "FK_Premios_Penca_PencaId",
                table: "Premios");

            migrationBuilder.DropIndex(
                name: "IX_Premios_PencaId",
                table: "Premios");

            migrationBuilder.DropIndex(
                name: "IX_Premios_UserId",
                table: "Premios");

            migrationBuilder.DropIndex(
                name: "IX_Predicsion_UserId",
                table: "Predicsion");

            migrationBuilder.DropColumn(
                name: "PencaId",
                table: "Premios");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Premios");

            migrationBuilder.DropColumn(
                name: "activa",
                table: "Penca");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Predicsion",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
