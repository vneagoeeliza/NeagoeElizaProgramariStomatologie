using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeagoeElizaProgramariStomatologie.Migrations
{
    /// <inheritdoc />
    public partial class emailPacient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medic_Specializare_SpecializareID",
                table: "Medic");

            migrationBuilder.DropIndex(
                name: "IX_Medic_SpecializareID",
                table: "Medic");

            migrationBuilder.DropColumn(
                name: "SpecializareID",
                table: "Medic");

            migrationBuilder.AddColumn<string>(
                name: "EmailPacient",
                table: "Pacient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailPacient",
                table: "Pacient");

            migrationBuilder.AddColumn<int>(
                name: "SpecializareID",
                table: "Medic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medic_SpecializareID",
                table: "Medic",
                column: "SpecializareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medic_Specializare_SpecializareID",
                table: "Medic",
                column: "SpecializareID",
                principalTable: "Specializare",
                principalColumn: "ID");
        }
    }
}
