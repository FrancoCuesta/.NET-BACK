using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class penca_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pencas_Campeonatos_CampeonatoId",
                table: "Pencas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pencas",
                table: "Pencas");

            migrationBuilder.DropIndex(
                name: "IX_Pencas_CampeonatoId",
                table: "Pencas");

            migrationBuilder.RenameTable(
                name: "Pencas",
                newName: "Penca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Penca",
                table: "Penca",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "User_Penca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PencaId = table.Column<int>(type: "int", nullable: false),
                    puntaje = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Penca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Penca_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Penca_Penca_PencaId",
                        column: x => x.PencaId,
                        principalTable: "Penca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Penca_PencaId",
                table: "User_Penca",
                column: "PencaId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Penca_UserId",
                table: "User_Penca",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Penca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Penca",
                table: "Penca");

            migrationBuilder.RenameTable(
                name: "Penca",
                newName: "Pencas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pencas",
                table: "Pencas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pencas_CampeonatoId",
                table: "Pencas",
                column: "CampeonatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pencas_Campeonatos_CampeonatoId",
                table: "Pencas",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
