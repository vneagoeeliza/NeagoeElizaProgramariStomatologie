using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeagoeElizaProgramariStomatologie.Migrations
{
    /// <inheritdoc />
    public partial class Medic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrenumeMedic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeMedic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializareID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Medic_Specializare_SpecializareID",
                        column: x => x.SpecializareID,
                        principalTable: "Specializare",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medic_SpecializareID",
                table: "Medic",
                column: "SpecializareID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medic");
        }
    }
}
