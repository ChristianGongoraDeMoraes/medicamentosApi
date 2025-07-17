using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace medicamentosApi.Migrations
{
    /// <inheritdoc />
    public partial class Horario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    appUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    medicamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horarios_AspNetUsers_appUserId",
                        column: x => x.appUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Horarios_Medicamentos_medicamentoId",
                        column: x => x.medicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_appUserId",
                table: "Horarios",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_medicamentoId",
                table: "Horarios",
                column: "medicamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horarios");
        }
    }
}
