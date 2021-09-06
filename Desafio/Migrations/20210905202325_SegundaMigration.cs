using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Migrations
{
    public partial class SegundaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NomesAgrupadosPorDataCriacao",
                columns: table => new
                {
                    IdNomes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomesAgrupadosPorData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomesAgrupadosPorDataCriacao", x => x.IdNomes);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NomesAgrupadosPorDataCriacao");
        }
    }
}
