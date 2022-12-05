using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class lista_partidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Campeonatoid",
                table: "Partidos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Campeonatoid",
                table: "Partidos",
                column: "Campeonatoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidos_Campeonatos_Campeonatoid",
                table: "Partidos",
                column: "Campeonatoid",
                principalTable: "Campeonatos",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partidos_Campeonatos_Campeonatoid",
                table: "Partidos");

            migrationBuilder.DropIndex(
                name: "IX_Partidos_Campeonatoid",
                table: "Partidos");

            migrationBuilder.DropColumn(
                name: "Campeonatoid",
                table: "Partidos");
        }
    }
}
