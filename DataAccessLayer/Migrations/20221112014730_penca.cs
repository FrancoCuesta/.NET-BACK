using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class penca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pencas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costo_entrada = table.Column<double>(type: "float", nullable: false),
                    poso = table.Column<double>(type: "float", nullable: false),
                    comision = table.Column<double>(type: "float", nullable: false),
                    cant_participantes = table.Column<int>(type: "int", nullable: false),
                    priada = table.Column<bool>(type: "bit", nullable: false),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    CampeonatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pencas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pencas_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pencas_CampeonatoId",
                table: "Pencas",
                column: "CampeonatoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pencas");
        }
    }
}
