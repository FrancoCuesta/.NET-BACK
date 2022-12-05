using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class predicsion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CampeonatoId",
                table: "Penca",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Predicsion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    golA = table.Column<int>(type: "int", nullable: false),
                    golB = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Partidoid = table.Column<int>(type: "int", nullable: false),
                    Pencaid = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predicsion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Predicsion_Partidos_Partidoid",
                        column: x => x.Partidoid,
                        principalTable: "Partidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Predicsion_Penca_Pencaid",
                        column: x => x.Pencaid,
                        principalTable: "Penca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Predicsion_Partidoid",
                table: "Predicsion",
                column: "Partidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Predicsion_Pencaid",
                table: "Predicsion",
                column: "Pencaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predicsion");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "Partidos");

            migrationBuilder.AlterColumn<int>(
                name: "CampeonatoId",
                table: "Penca",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
