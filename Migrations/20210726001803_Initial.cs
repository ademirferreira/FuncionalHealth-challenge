using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FuncionalBank.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContasCorrentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContasCorrentes", x => x.Id);
                    table.UniqueConstraint("AK_ContasCorrentes_Numero", x => x.Numero);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContasCorrentes_Id",
                table: "ContasCorrentes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContasCorrentes");
        }
    }
}
