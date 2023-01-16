using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeagoeElizaProgramariStomatologie.Migrations
{
    /// <inheritdoc />
    public partial class Programari : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataProgramare = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PacientID = table.Column<int>(type: "int", nullable: true),
                    ProceduraID = table.Column<int>(type: "int", nullable: true),
                    MedicID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Programare_Medic_MedicID",
                        column: x => x.MedicID,
                        principalTable: "Medic",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Pacient_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacient",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Programare_Procedura_ProceduraID",
                        column: x => x.ProceduraID,
                        principalTable: "Procedura",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programare_MedicID",
                table: "Programare",
                column: "MedicID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_PacientID",
                table: "Programare",
                column: "PacientID");

            migrationBuilder.CreateIndex(
                name: "IX_Programare_ProceduraID",
                table: "Programare",
                column: "ProceduraID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Programare");
        }
    }
}
