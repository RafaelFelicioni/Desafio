using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Migrations
{
    public partial class AjusteCampoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NomesAgrupadosPorDataCriacao",
                table: "NomesAgrupadosPorDataCriacao");

            migrationBuilder.RenameTable(
                name: "NomesAgrupadosPorDataCriacao",
                newName: "Nomes");

            migrationBuilder.AlterColumn<string>(
                name: "CriadoEm",
                table: "Nomes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nomes",
                table: "Nomes",
                column: "IdNomes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Nomes",
                table: "Nomes");

            migrationBuilder.RenameTable(
                name: "Nomes",
                newName: "NomesAgrupadosPorDataCriacao");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CriadoEm",
                table: "NomesAgrupadosPorDataCriacao",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NomesAgrupadosPorDataCriacao",
                table: "NomesAgrupadosPorDataCriacao",
                column: "IdNomes");
        }
    }
}
