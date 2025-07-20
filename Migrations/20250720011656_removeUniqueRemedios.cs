using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicamentosApi.Migrations
{
    /// <inheritdoc />
    public partial class removeUniqueRemedios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Medicamentos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_Nome",
                table: "Medicamentos",
                column: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medicamentos_Nome",
                table: "Medicamentos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Medicamentos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
